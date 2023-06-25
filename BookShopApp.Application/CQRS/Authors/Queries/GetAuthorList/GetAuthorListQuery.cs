using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList
{
    public class GetAuthorListQuery:IRequest<AuthorListViewModel>
    {
    }
}
