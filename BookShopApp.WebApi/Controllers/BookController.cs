using AutoMapper;
using BookShopApp.Application.Common.Mappings.DTOs;
using BookShopApp.Application.CQRS.Books.Commands.Create;
using BookShopApp.Application.CQRS.Books.Commands.Delete;
using BookShopApp.Application.CQRS.Books.Commands.Update;
using BookShopApp.Application.CQRS.Books.Queries.GetBookDetail;
using BookShopApp.Application.CQRS.Books.Queries.GetBookList;
using BookShopApp.Application.ViewModels;
using BookShopApp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController:BaseController
    {
        private IMapper _mapper;
        public BookController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ActionResult<BookListViewModel>> GetAll()
        {
            var query=new GetBookListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookLookupDto>> Get(int id)
        {
            var query = new GetBookDetailQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateBookDto bookDto)
        {
            var commnd = _mapper.Map<CreateBookCommand>(bookDto);
            var bookId = await Mediator.Send(commnd);

            return Ok(bookId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateBookDto bookDto)
        {
            var command = _mapper.Map<UpdateBookCommand>(bookDto);
            await Mediator.Send(command);

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
