using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Application.CQRS.Publishers.Commands.Create;

namespace BookShopApp.WebApi.Models
{
    public class CreatePublisherDto:IMapWith<CreatePublisherCommand>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int YearBegin { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePublisherDto,CreatePublisherCommand>()
                .ForMember(publisherCommand=>publisherCommand.Name,
                    opt=>opt.MapFrom(publisherDto=>publisherDto.Name))
                .ForMember(publisherCommand => publisherCommand.City,
                    opt => opt.MapFrom(publisherDto => publisherDto.City))
                .ForMember(publisherCommand => publisherCommand.YearBegin,
                    opt => opt.MapFrom(publisherDto => publisherDto.YearBegin));
        }
    }
}
