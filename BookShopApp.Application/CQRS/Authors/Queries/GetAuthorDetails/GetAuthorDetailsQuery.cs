using MediatR;

namespace BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorBiography
{
    public class GetAuthorDetailsQuery:IRequest<AuthorDetailsViewModel>
    {
        public int Id { get; set; }
    }
}
