﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Publishers.Commands.Create
{
    public class CreatePublisherCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int YearBegin { get; set; }
    }
}
