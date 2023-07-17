using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Income.Query
{
    public class GetIncomesOfBookQueryHandler : IRequestHandler<GetIncomesOfBookQuery, GetIncomesOfBookViewModel>
    {
        private IDataContext _dataContext;
        private IMapper _mapper;

        public GetIncomesOfBookQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<GetIncomesOfBookViewModel> Handle(GetIncomesOfBookQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dataContext.Income
                .Where(income => income.BookId == request.BookId)
                .ProjectTo<GetIncomeOfBookLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetIncomesOfBookViewModel { Incomes = entities };
        }
    }
}
