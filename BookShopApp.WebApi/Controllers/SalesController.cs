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
        private readonly IMediator Mediator;

        public SalesController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetSalesListQuery();
            var result = Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{dateBegin}/{dateEnd}")]
        public async Task<IActionResult> GetByDate(DateTime dateBegin, DateTime dateEnd)
        {
            var query = new GetSalesRangeListQuery { DateBegin = dateBegin, DateEnd = dateEnd };
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSaleCommand createSale)
        {
            await Mediator.Send(createSale);

            return NoContent();
        }
    }
}
