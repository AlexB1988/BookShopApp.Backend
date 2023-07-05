using BookShopApp.Application.ViewModels;
using MediatR;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBookList
{
    public class GetBookListQuery:IRequest<BookListViewModel>
    {
    }
}
