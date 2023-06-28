using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Application.CQRS.Publishers.Commands.Create;
using BookShopApp.Application.CQRS.Publishers.Commands.Update;

namespace BookShopApp.WebApi.Models
{
    public class UpdatePublisherDto:IMapWith<UpdatePublisherCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int YearBegin { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePublisherDto, UpdatePublisherCommand>()
                .ForMember(publisherCommand => publisherCommand.Id,
                    opt => opt.MapFrom(publisherDto => publisherDto.Id))
                .ForMember(publisherCommand => publisherCommand.Name,
                    opt => opt.MapFrom(publisherDto => publisherDto.Name))
                .ForMember(publisherCommand => publisherCommand.City,
                    opt => opt.MapFrom(publisherDto => publisherDto.City))
                .ForMember(publisherCommand => publisherCommand.YearBegin,
                    opt => opt.MapFrom(publisherDto => publisherDto.YearBegin));
        }
    }
}
