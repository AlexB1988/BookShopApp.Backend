﻿using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookShopApp.Application.CQRS.Price.Commands.Update
{
    public class UpdatePriceCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public decimal Price { get; set; }

        private class Handler : IRequestHandler<UpdatePriceCommand, Unit>
        {

            private readonly IDataContext _dataContext;

            public Handler(IDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
            {
                var price = await _dataContext.Prices.FirstOrDefaultAsync(price => price.Id == request.Id, cancellationToken);

                if (price == null)
                {
                    throw new NotFoundException(nameof(BookPrice), request.Id);
                }
                price.Price = request.Price;

                await _dataContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}