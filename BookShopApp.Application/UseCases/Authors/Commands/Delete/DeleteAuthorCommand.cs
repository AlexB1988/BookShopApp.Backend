using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;

namespace BookShopApp.Application.CommandsQueries.Authors.Commands.Delete
{
    public class DeleteAuthorCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        private class Handler : IRequestHandler<DeleteAuthorCommand, Unit> // TODO: В обновленном медиаторе если ты из команды ничего не возвращаешь, можно уже не писать и не возвращать Unit
        {

            private readonly IDataContext _dataContext;

            public Handler(IDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
            {

                var author = await _dataContext.Authors.FindAsync(request.Id, cancellationToken);

                if (author == null)
                {
                    throw new NotFoundException(nameof(Author), request.Id);
                }

                _dataContext.Authors.Remove(author);

                await _dataContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
