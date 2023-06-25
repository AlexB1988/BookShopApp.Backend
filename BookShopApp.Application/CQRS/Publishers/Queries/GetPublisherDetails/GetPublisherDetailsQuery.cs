using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherDetails
{
    public class GetPublisherDetailsQuery:IRequest<PublisherDetailsViewModel>
    {
        public int Id { get; set; }
    }
}
