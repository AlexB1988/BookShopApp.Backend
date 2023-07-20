using AutoMapper;
using BookShopApp.Application.CQRS.Income.Create;
using BookShopApp.Application.CQRS.Income.Query;
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
        public async Task<IActionResult> Get(int bookId)
        {
            var query = new GetIncomesOfBookQuery { BookId = bookId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIncomeCommand incomeCommand)
        {
            var incomeId = await _mediator.Send(incomeCommand);

            return Ok(incomeId);
        }
    }
}
