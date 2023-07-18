using MediatR;

namespace BookShopApp.Application.CQRS.Sales.Command.Create
{
    public class CreateSaleCommand : IRequest<Unit>
    {
        public IList<CreateSaleLookupDto> Sales { get; set; }
    }
}
