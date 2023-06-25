using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Books.Commands.DeleteBook
{
    public class DeleteBookCommand:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
