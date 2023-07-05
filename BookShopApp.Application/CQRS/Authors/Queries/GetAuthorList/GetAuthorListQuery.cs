using MediatR;

namespace BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList
{
    public class GetAuthorListQuery:IRequest<AuthorListViewModel>
    {
    }
}
