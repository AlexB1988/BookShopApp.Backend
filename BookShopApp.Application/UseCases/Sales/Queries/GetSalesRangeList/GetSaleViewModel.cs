using AutoMapper;
using BookShopApp.Application.Mappings;
using BookShopApp.Domain.Entities;


namespace BookShopApp.Application.UseCases.Sales.Queries.GetSalesRangeList
{
    public class GetSaleViewModel : IMapWith<Sale>
    {
        public int Id { get; set; }
        
        public string Book { get; set; }
        
        public int Amount { get; set; }
        
        public decimal Price { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Sale, GetSaleViewModel>()
                .ForMember(salesDto => salesDto.Id,
                    opt => opt.MapFrom(sales => sales.Id))
                .ForMember(salesDto => salesDto.Book,
                    opt => opt.MapFrom(sales => sales.Book.Name))
                .ForMember(salesDto => salesDto.Amount,
                    opt => opt.MapFrom(sales => sales.Amount))
                .ForMember(salesDto => salesDto.Price,
                    opt => opt.MapFrom(sales => sales.Book.Prices
                            .FirstOrDefault(price => price.DateEnd == null).Price))
                .ForMember(salesDto => salesDto.CreatedAt,
                    opt => opt.MapFrom(sales => sales.CreatedAt));
        }
    }
}
