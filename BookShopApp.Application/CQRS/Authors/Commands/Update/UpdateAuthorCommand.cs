using AutoMapper;
using BookShopApp.Application.Authors.Commands.Create;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;
using Newtonsoft.Json;

namespace BookShopApp.Application.CQRS.Authors.Commands.Update
{
    public class UpdateAuthorCommand : IRequest<Unit>,IMapWith<Author>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAuthorCommand, Author>()
                .ForMember(author => author.Id,
                    opt => opt.MapFrom(authorUpdate => authorUpdate.Id))
                .ForMember(author => author.Name,
                    opt => opt.MapFrom(authorUpdate => authorUpdate.Name))
                .ForMember(author => author.Biography,
                    opt => opt.MapFrom(authorUpdate => authorUpdate.Biography));
        }
    }
}
