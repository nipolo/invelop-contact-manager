using System;

namespace INV.ContactManager.Data.States
{
	public class ContactState
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string Surname { get; set; }

		public DateTime BirthDate { get; set; }

		public AddressState Address { get; set; }

		public string PhoneNumber { get; set; }

		public string IBAN { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime UpdatedOn { get; set; }
	}
}
