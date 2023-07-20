using BookShopApp.Application.Common.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;

namespace BookShopApp.Application.CommandsQueries.Authors.Commands.Delete
{
    // TODO: Расставь пустые строки и пробелы правильно. Блок переменных отделяется от конструктора пустой строкой. Конструктор отделяется от хэндлера пустой строкой.
    // Какие-то отдельные логические "абзацы" отделяй пустой строкой, всё подряд писать нельзя.
    // По поводу пробелов, тут все как в русском языке.

    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand,Unit> // TODO: В обновленном медиаторе если ты из команды ничего не возвращаешь, можно уже не писать и не возвращать Unit
    {
        private readonly IDataContext _dataContext;
        public DeleteAuthorCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dataContext.Authors.FindAsync(new object[] { request.Id }, cancellationToken);

            // TODO: Слишком сложно написал. 
            // var author = await _dataContext.Authors.FindAsync(request.Id, cancellationToken);
            // Обрати внимание, что название я дал "author", потому что мы достали автора из базы.
            // Обжект в аргументе делается когда у тебя составной/несколько ключей, по которым надо найти сущность.

            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            _dataContext.Authors.Remove(entity);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
