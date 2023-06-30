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
    // TODO: Контроллеры в множественном числе сущности: AuthorsController. Добавляем s в конце названия сущности
    public class AuthorController:BaseController
    {
        // TODO: Маппер здесь не нужен, это должно происходить в команде/сервисе. 
        // TODO: Такие приватный поля помечай также readonly, студия подсказывает тебе
        private IMapper _mapper;
        // Оставляй пустую строку между полями и конструктором. К синтаксису надо внимательно относится, не клади на него.
        public AuthorController(IMapper mapper)
        {
            _mapper = mapper;
        }
        // Тоже самое, тут тоже пробел должен быть
        [HttpGet]
        public async Task<ActionResult<AuthorListViewModel>> GetAll() // TODO: Такие методы обычно называем GetList. Но у тебя тоже нори название
        {
            var query = new GetAuthorListQuery();

            // TODO: Медиатор нужно зарегать в стартапе и сюда внедрять с помощью DI, как ты сделал с маппером. 
            // Только вместо маппера должен медиатор быть
            // TODO: На символах не экономь. Назови переменную result на крайняк, либо authorList
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDetailsViewModel>> Get(int Id)
        {
            // TODO: В одну строку: var query = new GetAuthorDetailsQuery { Id = id }; Если много полей, или они на них нужно обратить внимание, то в столбец

            var query = new GetAuthorDetailsQuery
            {
                Id = Id
            };

            var vm = await Mediator.Send(query); 
            return Ok(vm);
        }

        [HttpPost]
        // TODO: В параметр надо пихать срвзу команду, не дто. Каоманда по факту и является твоей дто. 
        public async Task<ActionResult<int>> Create([FromBody]CreateAuthorDto createAuthorDto)
        {
            var command = _mapper.Map<CreateAuthorCommand>(createAuthorDto);
            var authorId = await Mediator.Send(command);

            return Ok(authorId);
        }

        [HttpPut]
        // TODO: Почему где-то пишешь ActionResult, а где-то IActionResult? Пиши везде последний
        public async Task<IActionResult> Update([FromBody] /*Пробел между аттрибутом и параметром */ UpdateAuthorDto updateAuthorDto)
        {
            var command = _mapper.Map<UpdateAuthorCommand>(updateAuthorDto);
            await Mediator.Send(command);

            return NoContent();
        }

        // TODO: Пример апдейта

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] UpdateAuthorCommand command)
        //{
        //    command.Id = id;
        //    await _mediator.Send(command);

        //    return NoContent();
        //}

        // Удаление норм
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

        // PS Маршруты правильно прописал, молодец
    }
}
