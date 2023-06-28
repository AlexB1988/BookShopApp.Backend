using BookShopApp.Application.CommandsQueries.Authors.Commands.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Authors.Commands.Delete
{
    public class DeleteAuthorValidator:AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(deleteAuthorCommand =>
                deleteAuthorCommand.Id).NotNull().NotEqual(0);
        }
    }
}
