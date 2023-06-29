using BookShopApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Income.Query
{
    public class GetIncomesOfBookQuery:IRequest<GetIncomesOfBookViewModel>
    {
        public int BookId { get; set; }
    }
}
