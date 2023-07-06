using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using AutoMapper;

namespace BookShopApp.Application.CQRS.Publishers.Commands.Update
{
    public class UpdatePublisherCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int YearBegin { get; set; }
    }
}
