using BookShopApp.Application.CQRS.Books.Commands.Create;
using BookShopApp.Application.CQRS.Books.Commands.Delete;
using BookShopApp.Application.CQRS.Books.Commands.Update;
using BookShopApp.Application.CQRS.Books.Queries.GetBookDetail;
using BookShopApp.Application.CQRS.Books.Queries.GetBookList;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BooksController:BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query=new GetBookListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetBookDetailQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand createBook)
        {
            var bookId = await Mediator.Send(createBook);

            return Ok(bookId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int Id, [FromBody] UpdateBookCommand updateBook)
        {
            updateBook.Id = Id;
            await Mediator.Send(updateBook);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
