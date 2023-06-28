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

namespace BookShopApp.Application.CQRS.Publishers.Commands.Update
{
    public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommand, Unit>
    {
        private readonly IDataContext _dataContext;

        public UpdatePublisherCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dataContext.Publishers.FirstOrDefaultAsync(publisher => publisher.Id == request.Id,cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Publisher),request.Id);
            }

            entity.Name = request.Name;
            entity.YearBegin = request.YearBegin;
            entity.City = request.City;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
