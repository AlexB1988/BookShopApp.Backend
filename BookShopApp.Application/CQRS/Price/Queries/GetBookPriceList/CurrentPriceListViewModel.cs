

namespace BookShopApp.Application.CQRS.Price.Queries.GetBookPriceList
{
    public class CurrentPriceListViewModel
    {
        public IList<BookPriceDto> BookPriceList { get; set; }
    }
}
