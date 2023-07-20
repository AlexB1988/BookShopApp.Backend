using AutoMapper;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList;
using BookShopApp.Domain.Entities;

namespace BookShopApp.Application.Mappings.DTOs
{
    public class BookViewModel: IMapWith<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Amount { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public IList<AuthorViewModel> Authors { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookViewModel>()
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
                    opt => opt.MapFrom(book => book.Prices
                                        .FirstOrDefault(price => price.DateEnd == null).Price));
        }
    }
}
