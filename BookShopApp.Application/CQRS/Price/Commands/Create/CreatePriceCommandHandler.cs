using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Price.Commands.Create
{
    public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand, int>
    {
        private readonly IDataContext _dataContext;

        public CreatePriceCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
        {
            var lastPrice = await _dataContext.Prices.FirstOrDefaultAsync(price => price.BookId == request.BookId && price.DateEnd == null,cancellationToken);
            if(lastPrice != null)
            {
                lastPrice.DateEnd = DateTime.UtcNow;
            }
            var entityPrice = new BookPrice
            {
                BookId = request.BookId,
                Price = request.Price,
                DateBegin = DateTime.UtcNow
            };

            await _dataContext.Prices.AddAsync(entityPrice,cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return entityPrice.Id;
        }
    }
}
