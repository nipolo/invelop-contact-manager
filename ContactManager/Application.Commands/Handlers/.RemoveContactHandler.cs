using System.Threading;
using System.Threading.Tasks;

using INV.ContactManager.Application.Commands.Abstractions;
using INV.ContactManager.Application.Commands.Dtos.Contact;

using MediatR;

namespace INV.ContactManager.Application.Commands.Handlers
{
	public class RemoveContactHandler : IRequestHandler<RemoveContactCommand, Unit>
	{
		private readonly IContactService _contactService;

		public RemoveContactHandler(IContactService contactService)
		{
			_contactService = contactService;
		}

		public async Task<Unit> Handle(RemoveContactCommand request, CancellationToken cancellationToken)
		{
			await _contactService.RemoveContactAsync(request);

			return Unit.Value;
		}
	}
}
