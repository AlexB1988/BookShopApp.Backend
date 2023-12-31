﻿using BookShopApp.Application.Interfaces;
using BookShopApp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Income.Create
{
    public class CreateIncomeCommandHandler : IRequestHandler<CreateIncomeCommand, int>
    {
        private readonly IDataContext _dataContext;

        public CreateIncomeCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            var newIncome = new BookIncome
            {
                BookId = request.BookId,
                Amount = request.Amount,
                IncomePrice = request.IncomePrice
            };

            var currentAmount = await _dataContext.CurrentAmount.FirstOrDefaultAsync(amount=>amount.BookId==request.BookId);
            currentAmount.CurrentAmount += request.Amount;

            await _dataContext.Income.AddAsync(newIncome,cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return newIncome.Id;
        }
    }
}
