using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Price.Queries.GetBookPriceList
{
    public class GetCurrentPriceListQueryHandler : IRequestHandler<GetCurrentPriceListQuery, CurrentPriceListViewModel>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;
        public GetCurrentPriceListQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<CurrentPriceListViewModel> Handle(GetCurrentPriceListQuery request, CancellationToken cancellationToken)
        {
            var entityPriceList = await _dataContext.Prices
                .Where(price => price.DateEnd == null)
                .ProjectTo<BookPriceDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CurrentPriceListViewModel { BookPriceList=entityPriceList };
        }
    }
}
