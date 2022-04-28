using System.Threading;
using System.Threading.Tasks;

using INV.ContactManager.Application.Commands.Abstractions;
using INV.ContactManager.Application.Commands.Dtos.Contact;

using MediatR;

namespace INV.ContactManager.Application.Commands.Handlers
{
	public class CreateContactHandler : IRequestHandler<CreateContactCommand, Unit>
	{
		private readonly IContactService _contactService;

		public CreateContactHandler(IContactService contactService)
		{
			_contactService = contactService;
		}

		public async Task<Unit> Handle(CreateContactCommand request, CancellationToken cancellationToken)
		{
			await _contactService.CreateContactAsync(request);

			return Unit.Value;
		}
	}
}
