using System.Linq;
using System.Threading.Tasks;

using INV.ContactManager.Application.Queries.Abstractions;
using INV.ContactManager.Application.Queries.Dtos.Contact;
using INV.ContactManager.Data.Adapter;
using INV.ContactManager.Data.States;

using Microsoft.EntityFrameworkCore;

namespace INV.ContactManager.Application.Commands.Services
{
	public class ContactQueryService : IContactQueryService
	{
		private readonly IDbContextFactory<ContactManagerDBContext> _dbContextFactory;

		public ContactQueryService(
			IDbContextFactory<ContactManagerDBContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public async Task<AllContactsDto> GetAllContactsAsync(int pageNum, int pageSize)
		{
			using var dbContext = _dbContextFactory.CreateDbContext();

			var recordsToSkip = pageSize * (pageNum > 0 ? pageNum - 1 : 0);
			var contacts = await dbContext
					.Set<ContactState>()
					.AsNoTracking()
					.Skip(recordsToSkip)
					.Take(pageSize)
					.Select(x => new ContactDto()
					{
						Address = new AddressDto(
							x.Address.Line1, 
							x.Address.Line2, 
							x.Address.Postcode, 
							x.Address.City, 
							x.Address.Country),
						BirthDate = x.BirthDate,
						FirstName = x.FirstName,
						IBAN = x.IBAN,
						Id = x.Id,
						PhoneNumber = x.PhoneNumber,
						Surname = x.Surname
					})
					.ToListAsync();

			var totalContacts = await dbContext
					.Set<ContactState>()
					.AsNoTracking()
					.CountAsync();

			return new AllContactsDto()
			{
				Contacts = contacts,
				TotalContacts = totalContacts
			};
		}
	}
}
