using MediatR;

namespace BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherDetails
{
    public class GetPublisherDetailsQuery : IRequest<PublisherDetailsViewModel>
    {
        public int Id { get; set; }
    }
}
