using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorBiography;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
