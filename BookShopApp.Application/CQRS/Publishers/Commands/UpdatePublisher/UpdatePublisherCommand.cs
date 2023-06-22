using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Publishers.Commands.UpdatePublisher
{
    public class UpdatePublisherCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime DateBegin { get; set; }
    }
}
