using AutoMapper;
using BookShopApp.Application.Mappings;
using BookShopApp.Domain.Entities;

namespace BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList
{
    public class AuthorViewModel : IMapWith<Author>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author,AuthorViewModel>()
                .ForMember(authorDto=>authorDto.Id,
                    opt=>opt.MapFrom(author=>author.Id))
                .ForMember(authorDto=>authorDto.Name,
                    opt=>opt.MapFrom(author=>author.Name));
        }
    }
}
