﻿using AutoMapper;
using BookShopApp.Application.CQRS.Income.Create;
using BookShopApp.Application.CQRS.Income.Query;
using BookShopApp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class IncomesController:BaseController
    {
        private readonly IMapper _mapper;
        public IncomesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<GetIncomesOfBookViewModel>> Get(int bookId)
        {
            var query = new GetIncomesOfBookQuery
            {
                BookId = bookId
            };
            var vm = Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateIncomeCommand incomeDto)
        {
            var command = _mapper.Map<CreateIncomeCommand>(incomeDto);
            var incomeId = await Mediator.Send(command);

            return Ok(incomeId);
        }
    }
}
