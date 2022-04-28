using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using INV.ContactManager.Application.Queries.Abstractions;
using INV.ContactManager.Application.Commands.Dtos.Contact;
using INV.ContactManager.Application.Queries.Dtos.Contact;

using Microsoft.AspNetCore.Mvc;
using INV.ContactManager.Application.Commands.Abstractions;
using MediatR;

namespace INV.ContactManager.Api.Controllers
{
	[ApiController]
	[Route("api/contacts")]
	public class ContactController : ControllerBase
	{
		// private readonly IContactQueryService _contactQueryService;
		// private readonly IContactService _contactService;
		private readonly IMediator _mediator;

		public ContactController(
			// IContactQueryService contactQueryService,
			// IContactService contactService,
			IMediator mediator)
		{
			// _contactQueryService = contactQueryService;
			// _contactService = contactService;
			_mediator = mediator;
		}

		[HttpGet("all")]
		public async Task<ActionResult<AllContactsDto>> GetAllContactsAsync(
			[FromQuery][Required] int pageNum,
			[FromQuery][Required] int pageSize)
		{
			//var response = await _contactQueryService.GetAllContactsAsync(pageNum, pageSize);
			var response = await _mediator.Send(new AllContactsQuery(pageNum, pageSize));

			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> CreateContactAsync(
			[FromBody][Required] CreateContactCommand command)
		{
			// await _contactService.CreateContactAsync(command);
			await _mediator.Send(command);

			return Ok();
		}


		[HttpPut]
		public async Task<IActionResult> UpdateContactAsync(
			[FromBody][Required] UpdateContactCommand command)
		{
			// await _contactService.UpdateContactAsync(command);
			await _mediator.Send(command);

			return Ok();
		}


		[HttpDelete]
		public async Task<IActionResult> RemoveContactAsync(
			[FromBody][Required] RemoveContactCommand command)
		{
			// await _contactService.RemoveContactAsync(command);
			await _mediator.Send(command);

			return Ok();
		}
	}
}