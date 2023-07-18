using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Sales.Command.Queries.GetSalesRangeList
{
    public class GetSalesRangeListQueryHandler : IRequestHandler<GetSalesRangeListQuery, GetSalesListViewModel>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetSalesRangeListQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<GetSalesListViewModel> Handle(GetSalesRangeListQuery request, CancellationToken cancellationToken)
        {
            var sales = await _dataContext.Sales
                .Where(sales => sales.CreatedAt >= request.DateBegin && sales.CreatedAt <= request.DateEnd)
                .ProjectTo<GetSalesListDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetSalesListViewModel { SalesList = sales };
        }
    }
}
