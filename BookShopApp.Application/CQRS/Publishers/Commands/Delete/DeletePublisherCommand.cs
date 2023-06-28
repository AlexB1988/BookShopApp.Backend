using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Publishers.Commands.Delete
{
    public class DeletePublisherCommand:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
