using System.Threading.Tasks;

using INV.ContactManager.Application.Commands.Dtos.Contact;

namespace INV.ContactManager.Application.Commands.Abstractions
{
	public interface IContactService
	{
		Task CreateContactAsync(CreateContactCommand command);

		Task UpdateContactAsync(UpdateContactCommand command);

		Task RemoveContactAsync(RemoveContactCommand command);
	}
}