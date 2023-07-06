using AutoMapper;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;

namespace BookShopApp.Application.Authors.Commands.Create
{
    public class CreateAuthorCommand : IRequest<int>,IMapWith<Author>
    {
        public string Name { get; set; }
        public string Biography { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAuthorCommand, Author>()
                .ForMember(author => author.Name,
                    opt => opt.MapFrom(authorCommand => authorCommand.Name))
                .ForMember(author => author.Biography,
                    opt => opt.MapFrom(authorCommand => authorCommand.Biography)); 
        }
    }
}
