using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherList
{
    public class PublisherListViewModel
    {
        public IList<PublisherLookupDto> Publishers { get; set; }
    }
}
