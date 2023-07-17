using AutoMapper;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Price.Commands.Create
{
    public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand, int>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public CreatePriceCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
        {
            var lastPrice = await _dataContext.Prices
                .FirstOrDefaultAsync(price => price.BookId == request.BookId && price.DateEnd == null,cancellationToken);
            
            if(lastPrice != null)
            {
                lastPrice.DateEnd = DateTime.UtcNow;
            }

            var entityPrice = _mapper.Map<BookPrice>(request);

            await _dataContext.Prices.AddAsync(entityPrice,cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return entityPrice.Id;
        }
    }
}
