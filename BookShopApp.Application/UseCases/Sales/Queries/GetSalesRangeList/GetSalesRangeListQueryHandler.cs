using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.UseCases.Sales.Queries.GetSalesRangeList
{
    public class GetSalesRangeListQueryHandler : IRequestHandler<GetSalesRangeListQuery, ICollection<GetSaleViewModel>>
    {

        private readonly IDataContext _dataContext;

        private readonly IMapper _mapper;

        public GetSalesRangeListQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ICollection<GetSaleViewModel>> Handle(GetSalesRangeListQuery request, CancellationToken cancellationToken)
        {
            var sales = await _dataContext.Sales
                .Where(sales => sales.CreatedAt >= request.DateBegin && sales.CreatedAt <= request.DateEnd)
                .ProjectTo<GetSaleViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return sales;
        }
    }
}
