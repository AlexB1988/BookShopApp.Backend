using AutoMapper;
using BookShopApp.Application.Authors.Commands.Create;
using BookShopApp.Application.Common.Mappings;

namespace BookShopApp.WebApi.Models
{
    // TODO: Все эти ДТОхи не нужны, у тебя команда выполняет их роль
    // TODO: Более того, папка называется Models, а хранишь ты здесь DTO
    public class CreateAuthorDto:IMapWith<CreateAuthorCommand>
    {
        public string Name { get; set; }
        public string Biography { get; set; }

        public void Mapping(Profile profile)
        {
            // TODO: Если поля называются одинаково, необязательно явно указывать, автомаппер сам поймет
            profile.CreateMap<CreateAuthorDto, CreateAuthorCommand>()
                .ForMember(authorCommand => authorCommand.Name,
                    opt => opt.MapFrom(authorDto => authorDto.Name))
                .ForMember(authorCommand => authorCommand.Biography,
                    opt => opt.MapFrom(authorDto => authorDto.Biography));
        }
    }
}
