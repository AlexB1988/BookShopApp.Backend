using MediatR;

namespace BookShopApp.Application.CQRS.Sales.Command.Queries.GetSalesRangeList
{
    public class GetSalesRangeListQuery : IRequest<GetSalesListViewModel>
    {
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
