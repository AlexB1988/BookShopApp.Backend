﻿using AutoMapper;
using BookShopApp.Application.CQRS.Books.Queries.GetBookList;
using BookShopApp.Application.ViewModels;
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


    }
}
