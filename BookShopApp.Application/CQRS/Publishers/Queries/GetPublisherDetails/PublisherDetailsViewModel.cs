using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherDetails
{
    public class PublisherDetailsViewModel:IMapWith<Publisher>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int YearBegin { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Publisher,PublisherDetailsViewModel>()
                .ForMember(publisherVm => publisherVm.Id,
                    opt => opt.MapFrom(publisher => publisher.Id))
                .ForMember(publisherVm => publisherVm.Name,
                    opt => opt.MapFrom(publisher => publisher.Name))
                .ForMember(publisherVm => publisherVm.City,
                    opt => opt.MapFrom(publisher => publisher.City))
                .ForMember(publisherVm => publisherVm.YearBegin,
                    opt => opt.MapFrom(publisher => publisher.YearBegin));
        }
    }
}
