using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Income.Query
{
    public class GetIncomesOfBookQuery : IRequest<ICollection<GetIncomeViewModel>>
    {
        public int BookId { get; set; }

        private class Handler : IRequestHandler<GetIncomesOfBookQuery, ICollection<GetIncomeViewModel>>
        {

            private IDataContext _dataContext;

            private IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<ICollection<GetIncomeViewModel>> Handle(GetIncomesOfBookQuery request, CancellationToken cancellationToken)
            {
                var incomes = await _dataContext.Income
                    .Where(income => income.BookId == request.BookId)
                    .ProjectTo<GetIncomeViewModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return incomes;
            }
        }
    }
}
