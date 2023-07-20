using AutoMapper;
using BookShopApp.Application.Interfaces;
using BookShopApp.Application.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Income.Create
{
    public class CreateIncomeCommand : IRequest<int>, IMapWith<BookIncome>
    {

        public int BookId { get; set; }

        public int Amount { get; set; }

        public decimal IncomePrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateIncomeCommand, BookIncome>()
                .ForMember(income => income.BookId,
                    opt => opt.MapFrom(incomeCommand => incomeCommand.BookId))
                .ForMember(income => income.Amount,
                    opt => opt.MapFrom(incomeCommand => incomeCommand.Amount))
                .ForMember(income => income.IncomePrice,
                    opt => opt.MapFrom(incomeCommand => incomeCommand.IncomePrice));
        }

        private class Handler : IRequestHandler<CreateIncomeCommand, int>
        {
            private readonly IDataContext _dataContext;

            private readonly IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
            {

                var income = _mapper.Map<BookIncome>(request);

                var currentAmount = await _dataContext.CurrentAmount.FirstOrDefaultAsync(amount => amount.BookId == request.BookId);
                currentAmount.CurrentAmount += request.Amount;

                await _dataContext.Income.AddAsync(income, cancellationToken);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return income.Id;
            }
        }
    }
}
