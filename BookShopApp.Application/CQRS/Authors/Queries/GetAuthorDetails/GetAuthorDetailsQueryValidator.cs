using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorBiography;
using FluentValidation;

namespace BookShopApp.Application.CQRS.Authors.Queries.GetAuthorDetails
{
    public class GetAuthorDetailsQueryValidator:AbstractValidator<GetAuthorDetailsQuery>
    {
        public GetAuthorDetailsQueryValidator()
        {
            RuleFor(author =>
                author.Id).NotNull().NotEqual(0);
        }
    }
}
