using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Authors.Commands.Update
{
    public class UpdateAuthorCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
    }
}
