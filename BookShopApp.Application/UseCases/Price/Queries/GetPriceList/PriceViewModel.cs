using AutoMapper;
using BookShopApp.Application.Mappings;
using BookShopApp.Domain.Entities;

namespace BookShopApp.Application.CQRS.Price.Queries.GetBookPriceList
{
    public class PriceViewModel : IMapWith<BookPrice>
    {
        
        public int Id { get; set; }
        
        public int BookId { get; set; } 
        
        public string BookName { get; set; }
        
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BookPrice,PriceViewModel>()
                .ForMember(bookPriceDto => bookPriceDto.Id,
                    opt => opt.MapFrom(bookPrice => bookPrice.Id))
                .ForMember(bookPriceDto => bookPriceDto.BookId,
                    opt => opt.MapFrom(bookPrice => bookPrice.Book.Id))
                .ForMember(bookPriceDto=>bookPriceDto.BookName,
                    opt=>opt.MapFrom(bookPrice=>bookPrice.Book.Name))
                .ForMember(bookPriceDto=>bookPriceDto.Price,
                    opt=>opt.MapFrom(bookPrice=>bookPrice.Price));
        }
    }
}
