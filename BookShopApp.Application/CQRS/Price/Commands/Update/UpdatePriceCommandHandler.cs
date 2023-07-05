using BookShopApp.Application.Interfaces;
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
            var entity= await _dataContext.Prices.FirstOrDefaultAsync(price=>price.BookId==request.BookId && price.DateEnd ==null,cancellationToken);
            entity.Price=request.Price;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
