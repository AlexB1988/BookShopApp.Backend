using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorBiography
{
    public class GetAuthorBiographyQuery:IRequest<AuthorBiographyVm>
    {
        public int Id { get; set; }
    }
}
