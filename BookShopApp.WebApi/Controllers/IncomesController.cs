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
        private readonly IMediator Mediator;

        public IncomesController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<GetIncomesOfBookViewModel>> Get(int bookId)
        {
            var query = new GetIncomesOfBookQuery { BookId = bookId };
            var result = Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateIncomeCommand incomeCommand)
        {
            var incomeId = await Mediator.Send(incomeCommand);

            return Ok(incomeId);
        }
    }
}
