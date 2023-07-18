using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.CQRS.Sales.Command.Queries.GetSalesRangeList;
using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Sales.Command.Queries.GetSalesList
{
    public class GetSalesQueryHandler : IRequestHandler<GetSalesListQuery, GetSalesListViewModel>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetSalesQueryHandler(IDataContext dataContext, IMapper mapper = null)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<GetSalesListViewModel> Handle(GetSalesListQuery request, CancellationToken cancellationToken)
        {
            var sales = await _dataContext.Sales
                .ProjectTo<GetSalesListDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetSalesListViewModel { SalesList = sales };
        }
    }
}
