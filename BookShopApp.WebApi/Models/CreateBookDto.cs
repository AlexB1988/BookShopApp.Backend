using AutoMapper;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Application.CQRS.Books.Commands.CreateBook;

namespace BookShopApp.WebApi.Models
{
    public class CreateBookDto:IMapWith<CreateBookCommand>
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int PublisherId { get; set; }
        public int BookIncomeAmount { get; set; }
        public decimal BookIncomePrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public IList<int> Authors { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDto, CreateBookCommand>()
                .ForMember(bookDto => bookDto.Name,
                    opt => opt.MapFrom(bookCommand => bookCommand.Name))
                .ForMember(bookDto => bookDto.Year,
                    opt => opt.MapFrom(bookCommand => bookCommand.Year))
                .ForMember(bookDto => bookDto.PublisherId,
                    opt => opt.MapFrom(bookCommand => bookCommand.PublisherId))
                .ForMember(bookDto => bookDto.BookIncomeAmount,
                    opt => opt.MapFrom(bookCommand => bookCommand.BookIncomeAmount))
                .ForMember(bookDto => bookDto.BookIncomePrice,
                    opt => opt.MapFrom(bookCommand => bookCommand.BookIncomePrice))
                .ForMember(bookDto => bookDto.CurrentPrice,
                    opt => opt.MapFrom(bookCommand => bookCommand.CurrentPrice))
                .ForMember(bookDto => bookDto.Authors,
                    opt => opt.MapFrom(bookCommand => bookCommand.Authors));
        }
    }
}
