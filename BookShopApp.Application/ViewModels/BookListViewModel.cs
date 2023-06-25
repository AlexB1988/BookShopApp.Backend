using BookShopApp.Application.Common.Mappings.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.ViewModels
{
    public class BookListViewModel
    {
        public IList<BookLookupDto> Books { get; set; }
    }
}
