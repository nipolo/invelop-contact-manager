using System;
using System.Threading.Tasks;

using FluentValidation;

using INV.Common.Libraries.Exceptions;
using INV.ContactManager.Application.Commands.Abstractions;
using INV.ContactManager.Application.Commands.Domain;
using INV.ContactManager.Application.Commands.Dtos.Contact;
using INV.ContactManager.Data.Adapter;
using INV.ContactManager.Data.States;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace INV.ContactManager.Application.Commands.Services
{
	public class ContactService : IContactService
	{
		private readonly ILogger<ContactService> _logger;
		private readonly IDbContextFactory<ContactManagerDBContext> _dbContextFactory;
		private readonly IValidator<Contact> _contactValidator;

		public ContactService(
			ILogger<ContactService> logger,
			IDbContextFactory<ContactManagerDBContext> dbContextFactory,
			IValidator<Contact> contactValidator)
		{
			_logger = logger;
			_dbContextFactory = dbContextFactory;
			_contactValidator = contactValidator;
		}

		public async Task CreateContactAsync(CreateContactCommand command)
		{
			_logger.LogInformation($"CreateContactCommand Requested - {command}");

			var newContact = Contact.Create(
				command.FirstName,
				command.Surname,
				command.BirthDate,
				command.PhoneNumber,
				command.IBAN,
				command.Address.Line1,
				command.Address.Line2,
				command.Address.Postcode,
				command.Address.City,
				command.Address.Country
				);

			await _contactValidator.ValidateAndThrowAsync(newContact);

			using var dbContext = _dbContextFactory.CreateDbContext();

			var newContactEntityEntry = await dbContext
				.Set<ContactState>()
				.AddAsync(new ContactState()
				{
					Address = new AddressState(
						newContact.Address.Line1,
						newContact.Address.Line2,
						newContact.Address.Postcode,
						newContact.Address.City,
						newContact.Address.Country),
					BirthDate = newContact.BirthDate,
					FirstName = newContact.FirstName,
					IBAN = newContact.IBAN,
					PhoneNumber = newContact.PhoneNumber,
					Surname = newContact.Surname,
					CreatedOn = newContact.CreatedOn,
					UpdatedOn = newContact.UpdatedOn
				});

			await dbContext.SaveChangesAsync();

			_logger.LogInformation($"CreateContactCommand Completed - Contact Id: {newContactEntityEntry.Entity.Id}");
		}

		public async Task UpdateContactAsync(UpdateContactCommand command)
		{
			_logger.LogInformation($"UpdateContactCommand Requested - {command}");

			var contact = await GetContactAsync(command.Id);

			if (contact == null)
			{
				throw new EntityNotFoundException<int>(command.Id);
			}

			contact.Update(
				command.FirstName,
				command.Surname,
				command.BirthDate,
				command.PhoneNumber,
				command.IBAN,
				command.Address.Line1,
				command.Address.Line2,
				command.Address.Postcode,
				command.Address.City,
				command.Address.Country
				);

			await _contactValidator.ValidateAndThrowAsync(contact);

			await UpdateContactStateAsync(contact);

			_logger.LogInformation($"UpdateContactCommand Completed - Contact Id: {command.Id}");
		}

		public async Task RemoveContactAsync(RemoveContactCommand command)
		{
			_logger.LogInformation($"RemoveContactCommand Requested - {command}");

			var contactState = await GetContactStateAsync(command.Id);

			if (contactState == null)
			{
				throw new EntityNotFoundException<int>(command.Id);
			}

			using var dbContext = _dbContextFactory.CreateDbContext();

			dbContext.Remove(contactState);

			await dbContext.SaveChangesAsync();

			_logger.LogInformation($"RemoveContactCommand Completed - Contact Id: {command.Id}");
		}

		private async Task<Contact> GetContactAsync(int id)
		{
			using var dbContext = _dbContextFactory.CreateDbContext();

			var state = await GetContactStateAsync(id);

			if (state == null)
			{
				return null;
			}

			var aggregate = Contact.Load(
				state.Id,
				state.FirstName,
				state.Surname,
				state.BirthDate,
				state.PhoneNumber,
				state.IBAN,
				state.Address.Line1,
				state.Address.Line2,
				state.Address.Postcode,
				state.Address.City,
				state.Address.Country,
				state.CreatedOn,
				state.UpdatedOn
				);

			return aggregate;
		}

		private async Task<ContactState> GetContactStateAsync(int id)
		{
			using var dbContext = _dbContextFactory.CreateDbContext();

			var state = await dbContext
				.Set<ContactState>()
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == id);

			return state;
		}

		private async Task UpdateContactStateAsync(Contact contact)
		{
			var state = new ContactState()
			{
				Id = contact.Id,
				Address = new AddressState(
							contact.Address.Line1,
							contact.Address.Line2,
							contact.Address.Postcode,
							contact.Address.City,
							contact.Address.Country),
				BirthDate = contact.BirthDate,
				CreatedOn = contact.CreatedOn,
				FirstName = contact.FirstName,
				IBAN = contact.IBAN,
				PhoneNumber = contact.PhoneNumber,
				Surname = contact.Surname,
				UpdatedOn = contact.UpdatedOn
			};

			var dbContext = _dbContextFactory.CreateDbContext();

			dbContext.Update(state);

			await dbContext.SaveChangesAsync();
		}
	}
}
