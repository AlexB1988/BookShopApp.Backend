using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Price.Queries.GetBookPriceList
{
    public class GetBookPriceListQueryHandler : IRequestHandler<GetBookPriceListQuery, BookPriceListViewModel>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;
        public GetBookPriceListQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<BookPriceListViewModel> Handle(GetBookPriceListQuery request, CancellationToken cancellationToken)
        {
            var entityPriceList = await _dataContext.Prices
                .Where(price => price.DateEnd == null)
                .ProjectTo<BookPriceDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BookPriceListViewModel { BookPriceList=entityPriceList };
        }
    }
}
