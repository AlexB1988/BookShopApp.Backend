using AutoMapper;
using BookShopApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherDetails
{
    public class PublisherDetailsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime DateBegin { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PublisherDetailsVm, Publisher>()
                .ForMember(publisherVm => publisherVm.Id,
                    opt => opt.MapFrom(publisher => publisher.Id))
                .ForMember(publisherVm => publisherVm.Name,
                    opt => opt.MapFrom(publisher => publisher.Name))
                .ForMember(publisherVm => publisherVm.City,
                    opt => opt.MapFrom(publisher => publisher.City))
                .ForMember(publisherVm => publisherVm.DateBegin,
                    opt => opt.MapFrom(publisher => publisher.DateBegin));
        }
    }
}
