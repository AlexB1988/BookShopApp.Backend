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
        public int PublisherId { get; set; }
        public int BookIncomeAmount { get; set; }
        public decimal BookIncomePrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public IList<int> Authors { get; set; }
    }
}
