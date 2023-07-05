

namespace BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherList
{
    public class GetPublisherListViewModel
    {
        public IList<PublisherLookupDto> Publishers { get; set; }
    }
}
