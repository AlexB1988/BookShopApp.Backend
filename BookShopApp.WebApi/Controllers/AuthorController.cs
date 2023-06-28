using AutoMapper;
using BookShopApp.Application.Authors.Commands.Create;
using BookShopApp.Application.CommandsQueries.Authors.Commands.Delete;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorBiography;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList;
using BookShopApp.Application.CQRS.Authors.Commands.Update;
using BookShopApp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController:BaseController
    {
        private IMapper _mapper;
        public AuthorController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<AuthorListViewModel>> GetAll()
        {
            var query = new GetAuthorListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDetailsViewModel>> Get(int Id)
        {
            var query = new GetAuthorDetailsQuery
            {
                Id = Id
            };

            var vm = await Mediator.Send(query); 
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody]CreateAuthorDto createAuthorDto)
        {
            var command = _mapper.Map<CreateAuthorCommand>(createAuthorDto);
            var authorId = await Mediator.Send(command);

            return Ok(authorId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateAuthorDto updateAuthorDto)
        {
            var command = _mapper.Map<UpdateAuthorCommand>(updateAuthorDto);
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAuthorCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
