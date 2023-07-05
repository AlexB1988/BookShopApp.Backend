using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Application.CQRS.Income.Create;

namespace BookShopApp.WebApi.Models
{
    public class CreateIncomeDto:IMapWith<CreateIncomeCommand>
    {
        public int BookId { get; set; }
        public int Amount { get; set; }
        public decimal IncomePrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateIncomeDto, CreateIncomeCommand>()
                .ForMember(incomeDto => incomeDto.BookId,
                    opt => opt.MapFrom(incomeCommand => incomeCommand.BookId))
                .ForMember(incomeDto => incomeDto.Amount,
                    opt => opt.MapFrom(incomeCommand => incomeCommand.Amount))
                .ForMember(incomeDto => incomeDto.IncomePrice,
                    opt => opt.MapFrom(incomeCommand => incomeCommand.IncomePrice));
        }
    }
}
