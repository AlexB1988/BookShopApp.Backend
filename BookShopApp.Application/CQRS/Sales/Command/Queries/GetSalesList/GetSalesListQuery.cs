using BookShopApp.Application.CQRS.Sales.Command.Queries.GetSalesRangeList;
using MediatR;

namespace BookShopApp.Application.CQRS.Sales.Command.Queries.GetSalesList
{
    public class GetSalesListQuery : IRequest<GetSalesListViewModel>
    {
    }
}
