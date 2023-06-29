using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Application.CQRS.Price.Commands.Create;

namespace BookShopApp.WebApi.Models
{
    public class CreatePriceDto:IMapWith<CreatePriceCommand>
    {
        public int BookId { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePriceDto, CreatePriceCommand>()
                .ForMember(priceDto => priceDto.BookId,
                    opt => opt.MapFrom(bookCommand => bookCommand.BookId))
                .ForMember(priceDto => priceDto.Price,
                    opt => opt.MapFrom(bookCommand => bookCommand.Price));
        }
    }
}
