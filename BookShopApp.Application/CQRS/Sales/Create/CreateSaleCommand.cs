using MediatR;

namespace BookShopApp.Application.CQRS.Sales.Create
{
    public class CreateSaleCommand : IRequest<Unit>
    {
        public IList<CreateSaleLookupDto> Sales { get; set; }
    }
}
