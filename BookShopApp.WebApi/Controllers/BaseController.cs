using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BookShopApp.WebApi.Controllers
{
    // TODO: Не нужно. Медиатор надо зарегать в стартапе (как маппер например) и втыкать его через конструктор.
    // А Контроллеры должны наследоваться от ControllerBase. По крайней мере в твоем случае, а так такой подход имеет место быть, если есть на то необходимость.
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController:ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator=>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
