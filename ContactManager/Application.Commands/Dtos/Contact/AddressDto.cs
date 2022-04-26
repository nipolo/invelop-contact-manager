using System.ComponentModel.DataAnnotations;

namespace INV.ContactManager.Application.Commands.Dtos.Contact
{
	public class AddressDto
	{
		[Required]
		public string Line1 { get; set; }

		public string Line2 { get; set; }

		[Required]
		public string City { get; set; }

		[Required]
		public string Country { get; set; }

		[Required]
		public string Postcode { get; set; }
	}
}
