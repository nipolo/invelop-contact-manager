using System.Threading.Tasks;

using INV.ContactManager.Application.Queries.Dtos.Contact;

namespace INV.ContactManager.Application.Queries.Abstractions
{
	public interface IContactQueryService
	{
		Task<AllContactsDto> GetAllContactsAsync(int pageNum, int pageSize);
	}
}