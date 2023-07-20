using FluentValidation;

namespace BookShopApp.Application.CQRS.Authors.Commands.Update
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.Name).NotEmpty().MaximumLength(100);
            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.Id).NotEmpty();
        }
    }
}
