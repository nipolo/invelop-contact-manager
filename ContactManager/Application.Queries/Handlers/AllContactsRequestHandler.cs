using System;
using System.Threading;
using System.Threading.Tasks;

using INV.ContactManager.Application.Queries.Abstractions;
using INV.ContactManager.Application.Queries.Dtos.Contact;

using MediatR;

namespace INV.ContactManager.Application.Queries.Handlers
{
	public class AllContactsRequestHandler : IRequestHandler<AllContactsQuery, AllContactsDto>
	{
		private readonly IContactQueryService _contactQueryService;

		public AllContactsRequestHandler(IContactQueryService contactQueryService)
		{
			_contactQueryService = contactQueryService;
		}

		public async Task<AllContactsDto> Handle(AllContactsQuery request, CancellationToken cancellationToken)
		{
			var response = await _contactQueryService.GetAllContactsAsync(request.PageNum, request.PageSize);

			return response;
		}
	}
}
