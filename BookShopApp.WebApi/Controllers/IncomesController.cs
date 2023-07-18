using AutoMapper;
using BookShopApp.Application.CQRS.Income.Create;
using BookShopApp.Application.CQRS.Income.Query;
using BookShopApp.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IncomesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<GetIncomesOfBookViewModel>> Get(int bookId)
        {
            var query = new GetIncomesOfBookQuery
            {
                BookId = bookId
            };
            var vm = Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateIncomeCommand incomeCommand)
        {
            var incomeId = await Mediator.Send(incomeCommand);

            return Ok(incomeId);
        }
    }
}
