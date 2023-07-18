using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;

namespace BookShopApp.Application.CQRS.Income.Create
{
    public class CreateIncomeCommand : IRequest<int>,IMapWith<BookIncome>
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
    }
}
