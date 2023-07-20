using AutoMapper;
using BookShopApp.Application.Mappings;
using BookShopApp.Domain.Entities;


namespace BookShopApp.Application.CQRS.Income.Query
{
    public class GetIncomeViewModel : IMapWith<BookIncome>
    {
        public int Id { get; set; }
        
        public int BookId { get; set; }
        
        public string Book { get; set; }
        
        public int Amount { get; set; }
        
        public decimal IncomePrice { get; set; }
        
        public DateTime DateIncome { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BookIncome,GetIncomeViewModel>()
                .ForMember(incomeDto=>incomeDto.Id,
                    opt=>opt.MapFrom(income=>income.Id))
                .ForMember(incomeDto => incomeDto.BookId,
                    opt => opt.MapFrom(income => income.BookId))
                .ForMember(incomeDto => incomeDto.Book,
                    opt => opt.MapFrom(income => income.Book.Name))
                .ForMember(incomeDto => incomeDto.Amount,
                    opt => opt.MapFrom(income => income.Amount))
                .ForMember(incomeDto => incomeDto.IncomePrice,
                    opt => opt.MapFrom(income => income.IncomePrice))
                .ForMember(incomeDto => incomeDto.DateIncome,
                    opt => opt.MapFrom(income => income.DateIncome));
        }
    }
}
