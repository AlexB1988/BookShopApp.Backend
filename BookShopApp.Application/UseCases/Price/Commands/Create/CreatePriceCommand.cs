using AutoMapper;
using BookShopApp.Application.Interfaces;
using BookShopApp.Application.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Price.Commands.Create
{
    public class CreatePriceCommand : IRequest<int>, IMapWith<BookPrice>
    {
        public int BookId { get; set; }

        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePriceCommand, BookPrice>()
                .ForMember(priceCreate => priceCreate.BookId,
                    opt => opt.MapFrom(price => price.BookId))
                .ForMember(priceCreate => priceCreate.Price,
                    opt => opt.MapFrom(price => price.Price));
        }

        private class Handler : IRequestHandler<CreatePriceCommand, int>
        {

            private readonly IDataContext _dataContext;

            private readonly IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
            {
                var lastPrice = await _dataContext.Prices
                    .FirstOrDefaultAsync(price => price.BookId == request.BookId && price.DateEnd == null, cancellationToken);

                if (lastPrice != null)
                {
                    lastPrice.DateEnd = DateTime.UtcNow;
                }

                var price = _mapper.Map<BookPrice>(request);

                await _dataContext.Prices.AddAsync(price, cancellationToken);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return price.Id;
            }
        }
    }
}
