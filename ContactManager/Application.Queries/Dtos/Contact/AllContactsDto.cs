using System.Collections.Generic;

namespace INV.ContactManager.Application.Queries.Dtos.Contact
{
	public class AllContactsDto
	{
		public IEnumerable<ContactDto> Contacts { get; set; }
	}
}
