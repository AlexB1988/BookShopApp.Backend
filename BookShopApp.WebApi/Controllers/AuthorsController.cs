using BookShopApp.Application.Authors.Commands.Create;
using BookShopApp.Application.CommandsQueries.Authors.Commands.Delete;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorBiography;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList;
using BookShopApp.Application.CQRS.Authors.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator Mediator;

        public AuthorsController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAuthorListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetAuthorDetailsQuery { Id = id };

            var vm = await Mediator.Send(query); 

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorCommand createAuthor)
        {
            var authorId = await Mediator.Send(createAuthor);

            return Ok(authorId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAuthorCommand updateAuthor)
        {
            updateAuthor.Id=id;
            await Mediator.Send(updateAuthor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAuthorCommand { Id = id };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
