using System;
using System.ComponentModel.DataAnnotations;

namespace INV.ContactManager.Application.Commands.Dtos.Contact
{
	public class UpdateContactCommand
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string Surname { get; set; }

		[Required]
		public DateTime BirthDate { get; set; }

		[Required]
		public AddressDto Address { get; set; }

		[Required]
		public string PhoneNumber { get; set; }

		[Required]
		public string IBAN { get; set; }
	}
}
