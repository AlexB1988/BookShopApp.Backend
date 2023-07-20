using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Publishers.Commands.Delete
{
    public class DeletePublisherCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        private class Handler : IRequestHandler<DeletePublisherCommand, Unit>
        {

            private readonly IDataContext _dataContext;

            public Handler(IDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
            {
                var publisher = await _dataContext.Publishers.FirstOrDefaultAsync(publisher => publisher.Id == request.Id);
                if (publisher == null)
                {
                    throw new NotFoundException(nameof(Publisher), request.Id);
                }

                _dataContext.Publishers.Remove(publisher);
                _dataContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}