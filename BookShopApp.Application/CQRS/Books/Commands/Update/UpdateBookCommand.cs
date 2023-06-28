using BookShopApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Books.Commands.Update
{
    public class UpdateBookCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int PublisherId { get; set; }
        public IList<int> Authors { get; set; }
    }
}
