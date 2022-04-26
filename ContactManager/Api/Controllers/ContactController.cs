using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using INV.ContactManager.Application.Queries.Abstractions;
using INV.ContactManager.Application.Commands.Dtos.Contact;
using INV.ContactManager.Application.Queries.Dtos.Contact;

using Microsoft.AspNetCore.Mvc;
using INV.ContactManager.Application.Commands.Abstractions;

namespace INV.ContactManager.Api.Controllers
{
	[ApiController]
	[Route("api/contacts")]
	public class ContactController : ControllerBase
	{
		private readonly IContactQueryService _contactQueryService;
		private readonly IContactService _contactService;

		public ContactController(
			IContactQueryService contactQueryService,
			IContactService contactService)
		{
			_contactQueryService = contactQueryService;
			_contactService = contactService;
		}

		[HttpGet("all")]
		public async Task<ActionResult<AllContactsDto>> GetAllContactsAsync(
			[FromQuery][Required] int pageNum,
			[FromQuery][Required] int pageSize)
		{
			var response = await _contactQueryService.GetAllContactsAsync(pageNum, pageSize);

			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> CreateContactAsync(
			[FromBody][Required] CreateContactCommand command)
		{
			await _contactService.CreateContactAsync(command);

			return Ok();
		}


		[HttpPut]
		public async Task<IActionResult> UpdateContactAsync(
			[FromBody][Required] UpdateContactCommand command)
		{
			await _contactService.UpdateContactAsync(command);

			return Ok();
		}


		[HttpDelete]
		public async Task<IActionResult> RemoveContactAsync(
			[FromBody][Required] RemoveContactCommand command)
		{
			await _contactService.RemoveContactAsync(command);

			return Ok();
		}
	}
}