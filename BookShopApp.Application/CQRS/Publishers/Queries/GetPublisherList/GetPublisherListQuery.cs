using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherList
{
    public class GetPublisherListQuery:IRequest<PublisherListViewModel>
    {
    }
}
