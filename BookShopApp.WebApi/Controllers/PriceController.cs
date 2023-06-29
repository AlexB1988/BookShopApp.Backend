using AutoMapper;
using BookShopApp.Application.CQRS.Books.Commands.Create;
using BookShopApp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PriceController:BaseController
    {
        private IMapper _mapper;

        public PriceController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //[HttpGet("{bbokId}")]

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateBookDto bookDto)
        {
            var command=_mapper.Map<CreateBookCommand>(bookDto);

            var priceId=await Mediator.Send(command);

            return Ok(priceId);
        }
    }
}
