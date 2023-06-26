using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Price.Queries.GetBookPriceList
{
    public class BookPriceListViewModel
    {
        public IList<BookPriceDto> BookPriceList { get; set; }
    }
}
