using AutoMapper;
using BookShopApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherList
{
    public class PublisherLookupDto
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
