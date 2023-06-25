using BookShopApp.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBooksByAuthor
{
    public class GetBooksByAuthorQuery:IRequest<BookListViewModel>
    {
        public int AuthorId { get; set; }
    }
}
