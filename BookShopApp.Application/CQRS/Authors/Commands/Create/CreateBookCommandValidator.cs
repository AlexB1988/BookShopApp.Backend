using BookShopApp.Application.Authors.Commands.Create;
using FluentValidation;

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
