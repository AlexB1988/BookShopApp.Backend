using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;

namespace BookShopApp.Application.CQRS.Price.Commands.Create
{
    public class CreatePriceCommand : IRequest<int>,IMapWith<BookPrice>
    {
        public int BookId { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePriceCommand, BookPrice>()
                .ForMember(priceCreate => priceCreate.BookId,
                    opt => opt.MapFrom(price => price.BookId))
                .ForMember(priceCreate => priceCreate.Price,
                    opt => opt.MapFrom(price => price.Price));
        }
    }
}
