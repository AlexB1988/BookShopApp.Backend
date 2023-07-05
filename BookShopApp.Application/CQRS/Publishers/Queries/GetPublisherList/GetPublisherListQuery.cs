using MediatR;

namespace BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherList
{
    public class GetPublisherListQuery : IRequest<GetPublisherListViewModel>
    {
    }
}
