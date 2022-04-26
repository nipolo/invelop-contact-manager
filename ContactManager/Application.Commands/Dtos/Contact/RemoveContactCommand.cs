using System.ComponentModel.DataAnnotations;

namespace INV.ContactManager.Application.Commands.Dtos.Contact
{
	public class RemoveContactCommand
	{
		[Required]
		public int Id { get; set; }
	}
}
