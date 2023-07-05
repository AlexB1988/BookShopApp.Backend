using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain.Entities;

namespace BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherList
{
    public class PublisherLookupDto : IMapWith<Publisher>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Publisher, PublisherLookupDto>()
                .ForMember(publisherDto => publisherDto.Id,
                    opt => opt.MapFrom(publisher => publisher.Id))
                .ForMember(publisherDto => publisherDto.Name,
                    opt => opt.MapFrom(publisher => publisher.Name));
        }
    }
}
