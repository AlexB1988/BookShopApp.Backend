using BookShopApp.Application.Common.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Price.Commands.Update
{
    public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand, Unit>
    {
        private readonly IDataContext _dataContext;

        public UpdatePriceCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
        {
            var entity= await _dataContext.Prices.FirstOrDefaultAsync(price => price.Id == request.Id, cancellationToken);

            if (entity==null)
            {
                throw new NotFoundException(nameof(BookPrice), request.Id);
            }
            entity.Price=request.Price;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
