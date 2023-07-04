using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList
{
    public class AuthorLookupDto:IMapWith<Author>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author,AuthorLookupDto>()
                .ForMember(authorDto=>authorDto.Id,
                    opt=>opt.MapFrom(author=>author.Id))
                .ForMember(authorDto=>authorDto.Name,
                    opt=>opt.MapFrom(author=>author.Name));
        }
    }
}
