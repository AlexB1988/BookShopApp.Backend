﻿using BookShopApp.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBookDetail
{
    public class GetBookDetailQuery:IRequest<BookViewModel>
    {
        public int Id { get; set; }
    }
}
