using AutoMapper;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain.Entities;

namespace BookShopApp.Application.Common.Mappings.DTOs
{
    // TODO: Что значит Lookup? Я сначала подумал что тип данных как словарь. Не изваращайся, просто называешь BookViewModel и все
    public class BookLookupDto : IMapWith<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Amount { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public IList<AuthorLookupDto> Authors { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookLookupDto>()
                .ForMember(bookDto => bookDto.Id,
                    opt => opt.MapFrom(book => book.Id))
                .ForMember(bookDto => bookDto.Name,
                    opt => opt.MapFrom(book => book.Name))
                .ForMember(bookDto => bookDto.Year,
                    opt => opt.MapFrom(book => book.Year))
                .ForMember(bookDto => bookDto.Amount,
                    opt => opt.MapFrom(book => book.Amount.CurrentAmount))
                .ForMember(bookDto => bookDto.Publisher,
                    opt => opt.MapFrom(book => book.Publisher.Name))
                .ForMember(bookDto => bookDto.Price,
                    opt => opt.MapFrom(book => book.Price
                                        .FirstOrDefault(price=>price.DateEnd==null).Price));
        }
    }
}
