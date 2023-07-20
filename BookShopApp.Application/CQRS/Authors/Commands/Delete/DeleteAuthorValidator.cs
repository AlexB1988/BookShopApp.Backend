using BookShopApp.Application.CommandsQueries.Authors.Commands.Delete;
using FluentValidation;

namespace BookShopApp.Application.CQRS.Authors.Commands.Delete
{
    public class DeleteAuthorValidator:AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(deleteAuthorCommand =>
                deleteAuthorCommand.Id).NotNull().NotEqual(0);  // TODO: Пишешь .NotEmpty() и он заменяет .NotNull и .NotEqual(0) одновременно. И если углубится, на нотНулл проверка избыточна, потому что у тебя интовый айдишник, он нуллом не может быть.
        }
    }
}
