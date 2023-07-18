using BookShopApp.Application.CQRS.Books.Commands.Create;
using BookShopApp.Application.CQRS.Books.Commands.Delete;
using BookShopApp.Application.CQRS.Books.Commands.Update;
using BookShopApp.Application.CQRS.Books.Queries.GetBookDetail;
using BookShopApp.Application.CQRS.Books.Queries.GetBookList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {

        private readonly IMediator Mediator;

        public BooksController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query=new GetBookListQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetBookDetailQuery { Id = id };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand createBook)
        {
            var bookId = await Mediator.Send(createBook);

            return Ok(bookId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookCommand updateBook)
        {
            updateBook.Id = id;
            await Mediator.Send(updateBook);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand { Id = id };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
