using BookShopApp.Application.CQRS.Publishers.Commands.Create;
using BookShopApp.Application.CQRS.Publishers.Commands.Delete;
using BookShopApp.Application.CQRS.Publishers.Commands.Update;
using BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherDetails;
using BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PublishersController : ControllerBase//BaseController
    {

        private readonly IMediator Mediator;

        public PublishersController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query=new GetPublisherListQuery();
            var vm=await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query =new GetPublisherDetailsQuery
            {
                Id = id
            };
            var vm=await Mediator.Send(query); 
            
            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePublisherCommand createPublisher)
        {
            var publisherId = await Mediator.Send(createPublisher);

            return Ok(publisherId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int Id, [FromBody] UpdatePublisherCommand updatePublisher)
        {
            updatePublisher.Id=Id;
            await Mediator.Send(updatePublisher);

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
