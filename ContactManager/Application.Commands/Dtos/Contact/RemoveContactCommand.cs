using System.ComponentModel.DataAnnotations;

using MediatR;

namespace INV.ContactManager.Application.Commands.Dtos.Contact
{
	public class RemoveContactCommand : IRequest
	{
		[Required]
		public int Id { get; set; }
	}
}
