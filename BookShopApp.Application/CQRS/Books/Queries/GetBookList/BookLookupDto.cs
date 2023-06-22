using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBookList
{
    public class BookLookupDto:IMapWith<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
