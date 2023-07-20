using BookShopApp.Application.CQRS.Sales.Command.Create;
using BookShopApp.Application.UseCases.Sales.Queries.GetSalesList;
using BookShopApp.Application.UseCases.Sales.Queries.GetSalesRangeList;
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

        [HttpGet("/dateRange")]
        public async Task<IActionResult> GetByDate([FromQuery] DateTime dateBegin, [FromQuery] DateTime dateEnd)
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
