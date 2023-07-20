using BookShopApp.Application.Common.Mappings.DTOs;

namespace BookShopApp.Application.ViewModels
{
    // TODO: Не нужно. Просто возвращашь коллекцию BookViewModel, как я говорил.
    public class BookListViewModel
    {
        public IList<BookLookupDto> Books { get; set; }
    }
}
