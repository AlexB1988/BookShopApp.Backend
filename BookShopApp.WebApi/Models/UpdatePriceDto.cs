using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Application.CQRS.Price.Commands.Update;

namespace BookShopApp.WebApi.Models
{
    public class UpdatePriceDto:IMapWith<UpdatePriceCommand>
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePriceDto, UpdatePriceCommand>()
                .ForMember(priceDto => priceDto.Id,
                    opt => opt.MapFrom(bookCommand => bookCommand.Id))
                .ForMember(priceDto => priceDto.BookId,
                    opt => opt.MapFrom(bookCommand => bookCommand.BookId))
                .ForMember(priceDto => priceDto.Price,
                    opt => opt.MapFrom(bookCommand => bookCommand.Price));
        }
    }
}
