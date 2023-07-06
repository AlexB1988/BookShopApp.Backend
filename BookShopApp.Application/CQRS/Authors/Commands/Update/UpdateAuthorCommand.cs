using AutoMapper;
using BookShopApp.Application.Authors.Commands.Create;
using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;
using Newtonsoft.Json;

namespace BookShopApp.Application.CQRS.Authors.Commands.Update
{
    public class UpdateAuthorCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
    }
}
