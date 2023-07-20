using AutoMapper;
using BookShopApp.Application.CQRS.Books.Commands.Create;
using BookShopApp.Application.CQRS.Price.Commands.Create;
using BookShopApp.Application.CQRS.Price.Commands.Update;
using BookShopApp.Application.CQRS.Price.Queries.GetBookPriceList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PricesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetCurrentPriceListQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePriceCommand priceCommand)
        {

            var priceId=await _mediator.Send(priceCommand);

            return Ok(priceId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePriceCommand priceCommand)
        {
            priceCommand.Id = id;
            await _mediator.Send(priceCommand);

            return NoContent();
        }
    }
}
