using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;

namespace BookShopApp.Application.CommandsQueries.Authors.Commands.Delete
{
    public class DeleteAuthorCommand : IRequest
    {
        public int Id { get; set; }

        private class Handler : IRequestHandler<DeleteAuthorCommand> 
        {

            private readonly IDataContext _dataContext;

            public Handler(IDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
            {

                var author = await _dataContext.Authors
                    .FindAsync(request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Author), request.Id);

                _dataContext.Authors.Remove(author);

                await _dataContext.SaveChangesAsync(cancellationToken);

            }
        }
    }
}
