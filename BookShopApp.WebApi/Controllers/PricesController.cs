using AutoMapper;
using BookShopApp.Application.CQRS.Books.Commands.Create;
using BookShopApp.Application.CQRS.Price.Commands.Create;
using BookShopApp.Application.CQRS.Price.Commands.Update;
using BookShopApp.Application.CQRS.Price.Queries.GetBookPriceList;
using BookShopApp.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricesController : ControllerBase
    {
        private readonly IMediator Mediator;

        public PricesController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CurrentPriceListViewModel>> GetAll()
        {
            var query = new GetCurrentPriceListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreatePriceCommand priceCommand)
        {

            var priceId=await Mediator.Send(priceCommand);

            return Ok(priceId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int Id, [FromBody] UpdatePriceCommand priceCommand)
        {
            priceCommand.Id = Id;
            await Mediator.Send(priceCommand);

            return NoContent();
        }
    }
}
