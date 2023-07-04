using AutoMapper;
using BookShopApp.Application.CQRS.Books.Commands.Create;
using BookShopApp.Application.CQRS.Price.Commands.Update;
using BookShopApp.Application.CQRS.Price.Queries.GetBookPriceList;
using BookShopApp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PricesController:BaseController
    {
        private IMapper _mapper;

        public PricesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CurrentPriceListViewModel>> GetAll()
        {
            var query = new GetCurrentPriceListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreatePriceDto priceDto)
        {
            var command=_mapper.Map<CreateBookCommand>(priceDto);

            var priceId=await Mediator.Send(command);

            return Ok(priceId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdatePriceDto priceDto)
        {
            var command = _mapper.Map<UpdatePriceCommand>(priceDto);
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
