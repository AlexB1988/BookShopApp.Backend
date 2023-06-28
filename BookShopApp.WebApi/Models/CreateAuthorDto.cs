using AutoMapper;
using BookShopApp.Application.Authors.Commands.Create;
using BookShopApp.Application.Common.Mappings;

namespace BookShopApp.WebApi.Models
{
    public class CreateAuthorDto:IMapWith<CreateAuthorCommand>
    {
        public string Name { get; set; }
        public string Biography { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAuthorDto, CreateAuthorCommand>()
                .ForMember(authorCommand => authorCommand.Name,
                    opt => opt.MapFrom(authorDto => authorDto.Name))
                .ForMember(authorCommand => authorCommand.Biography,
                    opt => opt.MapFrom(authorDto => authorDto.Biography));
        }
    }
}
