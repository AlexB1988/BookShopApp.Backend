using BookShopApp.Application.CQRS.Sales.Command.Create;
using BookShopApp.Application.CQRS.Sales.Command.Queries.GetSalesList;
using BookShopApp.Application.CQRS.Sales.Command.Queries.GetSalesRangeList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetSalesListQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{dateBegin}/{dateEnd}")] // TODO: Такое лучше через FromQuery делать.
        public async Task<IActionResult> GetByDate(DateTime dateBegin, DateTime dateEnd)
        {
            var query = new GetSalesRangeListQuery { DateBegin = dateBegin, DateEnd = dateEnd };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSaleCommand createSale)
        {
            await _mediator.Send(createSale);

            return NoContent();
        }
    }
}
