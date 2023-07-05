using BookShopApp.Application.Common.Mappings.DTOs;

namespace BookShopApp.Application.ViewModels
{
    public class BookListViewModel
    {
        public IList<BookLookupDto> Books { get; set; }
    }
}
