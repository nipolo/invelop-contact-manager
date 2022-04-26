using System;

namespace INV.ContactManager.Application.Queries.Dtos.Contact
{
	public class ContactDto
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string Surname { get; set; }

		public DateTime BirthDate { get; set; }

		public AddressDto Address { get; set; }

		public string PhoneNumber { get; set; }

		public string IBAN { get; set; }
	}
}