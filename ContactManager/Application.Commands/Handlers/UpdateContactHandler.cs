using System.Threading;
using System.Threading.Tasks;

using INV.ContactManager.Application.Commands.Abstractions;
using INV.ContactManager.Application.Commands.Dtos.Contact;

using MediatR;

namespace INV.ContactManager.Application.Commands.Handlers
{
	public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, Unit>
	{
		private readonly IContactService _contactService;

		public UpdateContactHandler(IContactService contactService)
		{
			_contactService = contactService;
		}

		public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
		{
			await _contactService.UpdateContactAsync(request);

			return Unit.Value;
		}
	}
}
