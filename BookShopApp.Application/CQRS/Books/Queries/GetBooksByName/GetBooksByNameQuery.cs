using BookShopApp.Application.ViewModels;
using MediatR;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBooksByName
{
    public class GetBooksByNameQuery:IRequest<BookListViewModel>
    {
        public string Name { get; set; }
    }
}
