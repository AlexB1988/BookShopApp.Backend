using BookShopApp.Application.CQRS.Sales.Command.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator Mediator;

        public SalesController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSaleCommand createSale)
        {
            await Mediator.Send(createSale);

            return NoContent();
        }
    }
}
