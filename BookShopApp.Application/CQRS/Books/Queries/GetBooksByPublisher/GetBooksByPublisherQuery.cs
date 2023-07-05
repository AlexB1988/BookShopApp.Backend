using BookShopApp.Application.ViewModels;
using MediatR;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBooksByPublisher
{
    public class GetBooksByPublisherQuery:IRequest<BookListViewModel>
    {
        public int PublisherId { get; set; }
    }
}
