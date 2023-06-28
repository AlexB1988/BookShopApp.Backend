using AutoMapper;
using BookShopApp.Application.Authors.Commands.Create;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Application.CQRS.Authors.Commands.Update;

namespace BookShopApp.WebApi.Models
{
    public class UpdateAuthorDto:IMapWith<UpdateAuthorCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAuthorDto, UpdateAuthorCommand>()
                .ForMember(authorCommand => authorCommand.Id,
                    opt => opt.MapFrom(authorDto => authorDto.Id))
                .ForMember(authorCommand => authorCommand.Name,
                    opt => opt.MapFrom(authorDto => authorDto.Name))
                .ForMember(authorCommand => authorCommand.Biography,
                    opt => opt.MapFrom(authorDto => authorDto.Biography));
        }
    }
}
