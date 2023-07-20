using BookShopApp.Application.CommandsQueries.Authors.Commands.Delete;
using FluentValidation;

namespace BookShopApp.Application.CQRS.Authors.Commands.Delete
{
    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(deleteAuthorCommand =>
                deleteAuthorCommand.Id).NotEmpty();
        }
    }
}
