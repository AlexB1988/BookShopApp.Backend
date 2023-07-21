using AutoMapper;
using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Sales.Command.Create
{
    public class CreateSaleCommand : IRequest
    {
        public ICollection<CreateSaleViewModel> Sales { get; set; }

        private class Handler : IRequestHandler<CreateSaleCommand>
        {

            private readonly IDataContext _dataContext;

            private readonly IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task Handle(CreateSaleCommand request, CancellationToken cancellationToken)
            {
                var sales = _mapper.Map<List<Sale>>(request.Sales);

                foreach (var sale in sales)
                {
                    var currentAmount = await _dataContext.CurrentAmount
                        .FirstOrDefaultAsync(book => book.BookId == sale.BookId, cancellationToken);

                    if (currentAmount.CurrentAmount < sale.Amount)
                    {
                        throw new BadRequestException("такого кол-ва книг нет на складе");
                    }

                    currentAmount.CurrentAmount -= sale.Amount;

                    await _dataContext.Sales.AddAsync(sale, cancellationToken);
                }

                await _dataContext.SaveChangesAsync(cancellationToken);

            }
        }
    }
}
