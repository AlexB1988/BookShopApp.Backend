using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBookList
{
    public class BoolListVm
    {
        public IList<BookLookupDto> Books { get; set; }
    }
}
