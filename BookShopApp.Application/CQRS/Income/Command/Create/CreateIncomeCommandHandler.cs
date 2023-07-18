using AutoMapper;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Income.Create
{
    public class CreateIncomeCommandHandler : IRequestHandler<CreateIncomeCommand, int>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public CreateIncomeCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            //var newIncome = new BookIncome
            //{
            //    BookId = request.BookId,
            //    Amount = request.Amount,
            //    IncomePrice = request.IncomePrice
            //};

            var entity = _mapper.Map<BookIncome>(request);

            var currentAmount = await _dataContext.CurrentAmount.FirstOrDefaultAsync(amount=>amount.BookId==request.BookId);
            currentAmount.CurrentAmount += request.Amount;

            await _dataContext.Income.AddAsync(entity,cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
