using BookShopApp.Application.Common.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Publishers.Commands.DeletePublisher
{
    public class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommand, Unit>
    {
        private readonly IDataContext _dataContext;

        public DeletePublisherCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
        {
            var entity =await _dataContext.Publishers.FirstOrDefaultAsync(publisher => publisher.Id == request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Publisher), request.Id);
            }

            _dataContext.Publishers.Remove(entity);
            _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
