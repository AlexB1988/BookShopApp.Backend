using MediatR;

namespace BookShopApp.Application.CQRS.Price.Commands.Create
{
    public class CreatePriceCommand : IRequest<int>
    {
        public int BookId { get; set; }
        public decimal Price { get; set; }
    }
}
