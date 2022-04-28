using MediatR;

namespace INV.ContactManager.Application.Queries.Dtos.Contact
{
	public class AllContactsQuery : IRequest<AllContactsDto>
	{
		public AllContactsQuery(int pageNum, int pageSize)
		{
			PageNum = pageNum;
			PageSize = pageSize;
		}

		public int PageNum { get; set; }

		public int PageSize { get; set; }
	}
}
