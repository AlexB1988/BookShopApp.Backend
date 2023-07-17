using MediatR;
using Newtonsoft.Json;

namespace BookShopApp.Application.CQRS.Price.Commands.Update
{
    public class UpdatePriceCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public decimal Price { get; set; }
    }
}
