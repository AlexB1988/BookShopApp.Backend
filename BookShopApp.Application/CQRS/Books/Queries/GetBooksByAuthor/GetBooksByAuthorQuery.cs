using BookShopApp.Application.ViewModels;
using MediatR;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBooksByAuthor
{
    public class GetBooksByAuthorQuery:IRequest<BookListViewModel>
    {
        public int AuthorId { get; set; }
    }
}
