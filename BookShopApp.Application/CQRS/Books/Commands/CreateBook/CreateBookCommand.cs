using BookShopApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Books.Commands.CreateBook
{
    public class CreateBookCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Publisher Publisher { get; set; }
        public BookAmount BookAmount { get; set; }
        public BookPrice BookPrice { get; set; }
        public IList<Author> Authors { get; set; }
    }
}
