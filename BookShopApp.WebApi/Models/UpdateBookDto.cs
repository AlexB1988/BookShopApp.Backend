using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Application.CQRS.Books.Commands.Update;

namespace BookShopApp.WebApi.Models
{
    public class UpdateBookDto:IMapWith<UpdateBookCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int PublisherId { get; set; }
        public IList<int> Authors { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBookDto, UpdateBookCommand>()
                .ForMember(bookDto => bookDto.Id,
                    opt => opt.MapFrom(bookCommand => bookCommand.Id))
                .ForMember(bookDto => bookDto.Name,
                    opt => opt.MapFrom(bookCommand => bookCommand.Name))
                .ForMember(bookDto => bookDto.Year,
                    opt => opt.MapFrom(bookCommand => bookCommand.Year))
                .ForMember(bookDto => bookDto.PublisherId,
                    opt => opt.MapFrom(bookCommand => bookCommand.PublisherId))
                .ForMember(bookDto => bookDto.Authors,
                    opt => opt.MapFrom(bookCommand => bookCommand.Authors));
        }
    }
}
