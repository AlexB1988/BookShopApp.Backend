using AutoMapper;
using BookShopApp.Application.CQRS.Publishers.Commands.Create;
using BookShopApp.Application.CQRS.Publishers.Commands.Delete;
using BookShopApp.Application.CQRS.Publishers.Commands.Update;
using BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherDetails;
using BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherList;
using BookShopApp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PublisherController:BaseController
    {
        private IMapper _mapper;

        public PublisherController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<GetPublisherListViewModel>> GetAll()
        {
            var query=new GetPublisherListQuery();
            var vm=await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PublisherDetailsViewModel>> Get(int id)
        {
            var query =new GetPublisherDetailsQuery
            {
                Id = id
            };
            var vm=await Mediator.Send(query); 
            
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreatePublisherDto publisherDto)
        {
            var command =_mapper.Map<CreatePublisherCommand>(publisherDto);


            var publisherId = await Mediator.Send(command);

            return Ok(publisherId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePublisherDto publisherDto)
        {
            var command = _mapper.Map<UpdatePublisherCommand>(publisherDto);
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePublisherCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
