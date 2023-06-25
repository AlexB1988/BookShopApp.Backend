using AutoMapper;
using BookShopApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorBiography
{
    public class AuthorDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorDetailsViewModel>()
                .ForMember(authorVm => authorVm.Id,
                    opt => opt.MapFrom(author => author.Id))
                .ForMember(authorVm => authorVm.Name,
                    opt => opt.MapFrom(author => author.Name))
                .ForMember(authorVm => authorVm.Biography,
                    opt => opt.MapFrom(author => author.Biography));
        }
    }
}
