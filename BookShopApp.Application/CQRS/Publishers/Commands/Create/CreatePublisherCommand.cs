﻿using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;

namespace BookShopApp.Application.CQRS.Publishers.Commands.Create
{
    public class CreatePublisherCommand : IRequest<int>, IMapWith<Publisher>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int YearBegin { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePublisherCommand, Publisher>()
                .ForMember(publisher => publisher.Name,
                    opt => opt.MapFrom(publisherCreate => publisherCreate.Name))
                .ForMember(publisher => publisher.City,
                    opt => opt.MapFrom(publisherCreate => publisherCreate.City))
                .ForMember(publisher => publisher.YearBegin,
                    opt => opt.MapFrom(publisherCreate => publisherCreate.YearBegin));
        }
    }
}
