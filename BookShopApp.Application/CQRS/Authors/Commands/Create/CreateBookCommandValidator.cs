using BookShopApp.Application.Authors.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Authors.Commands.Create
{
    public class CreateBookCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(createAuthorCommand =>
                createAuthorCommand.Name).NotEmpty().MaximumLength(100);
        }
    }
}
