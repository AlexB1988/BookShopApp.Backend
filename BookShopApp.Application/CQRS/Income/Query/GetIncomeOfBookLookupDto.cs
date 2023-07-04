using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Income.Query
{
    public class GetIncomeOfBookLookupDto:IMapWith<BookIncome>
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Book { get; set; }
        public int Amount { get; set; }
        public decimal IncomePrice { get; set; }
        public DateTime DateIncome { get; set; } = DateTime.UtcNow;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BookIncome,GetIncomeOfBookLookupDto>()
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
