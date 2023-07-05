using MediatR;

namespace BookShopApp.Application.CQRS.Price.Queries.GetBookPriceList
{
    public class GetCurrentPriceListQuery : IRequest<CurrentPriceListViewModel>
    {

    }
}
