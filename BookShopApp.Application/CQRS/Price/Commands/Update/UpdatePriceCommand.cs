﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Price.Commands.Update
{
    public class UpdatePriceCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public decimal Price { get; set; }
    }
}
