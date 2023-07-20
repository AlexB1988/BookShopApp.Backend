using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Price.Queries.GetBookPriceList
{
    public class GetCurrentPriceListQuery : IRequest<ICollection<PriceViewModel>>
    {

        private class Handler : IRequestHandler<GetCurrentPriceListQuery, ICollection<PriceViewModel>>
        {
            private readonly IDataContext _dataContext;

            private readonly IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<ICollection<PriceViewModel>> Handle(GetCurrentPriceListQuery request, CancellationToken cancellationToken)
            {
                var priceList = await _dataContext.Prices
                    .Where(price => price.DateEnd == null)
                    .ProjectTo<PriceViewModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return priceList;
            }
        }
    }
}
