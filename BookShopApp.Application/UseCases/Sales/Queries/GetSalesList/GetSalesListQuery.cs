using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Application.UseCases.Sales.Queries.GetSalesRangeList;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.UseCases.Sales.Queries.GetSalesList
{
    public class GetSalesListQuery : IRequest<ICollection<GetSaleViewModel>>
    {

        private class Handler : IRequestHandler<GetSalesListQuery, ICollection<GetSaleViewModel>>
        {
            private readonly IDataContext _dataContext;

            private readonly IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper = null)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<ICollection<GetSaleViewModel>> Handle(GetSalesListQuery request, CancellationToken cancellationToken)
            {
                var sales = await _dataContext.Sales
                    .ProjectTo<GetSaleViewModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return sales;
            }
        }
    }
}
