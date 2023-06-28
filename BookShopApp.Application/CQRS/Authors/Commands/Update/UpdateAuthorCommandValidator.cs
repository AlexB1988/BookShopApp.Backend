using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Authors.Commands.Update
{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.Name).NotEmpty().MaximumLength(100);
            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.Id).NotNull().NotEqual(0);
        }
    }
}
