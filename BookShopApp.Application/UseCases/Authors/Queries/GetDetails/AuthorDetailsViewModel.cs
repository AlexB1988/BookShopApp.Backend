﻿using AutoMapper;
using BookShopApp.Application.Mappings;
using BookShopApp.Domain.Entities;

namespace BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorBiography
{
    public class AuthorViewModel : IMapWith<Author>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Biography { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorViewModel>()
                .ForMember(authorVm => authorVm.Id,
                    opt => opt.MapFrom(author => author.Id))
                .ForMember(authorVm => authorVm.Name,
                    opt => opt.MapFrom(author => author.Name))
                .ForMember(authorVm => authorVm.Biography,
                    opt => opt.MapFrom(author => author.Biography));
        }
    }
}