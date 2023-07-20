using AutoMapper;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Sales.Command.Create
{
    public class CreateSaleCommand : IRequest<Unit>
    {
        public ICollection<CreateSaleViewModel> Sales { get; set; }

        private class Handler : IRequestHandler<CreateSaleCommand, Unit>
        {
            private readonly IDataContext _dataContext;
            private readonly IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
            {
                var sales = _mapper.Map<List<Sale>>(request.Sales);

                foreach (var sale in sales)
                {
                    var currentAmount = await _dataContext.CurrentAmount
                        .FirstOrDefaultAsync(book => book.BookId == sale.BookId, cancellationToken);
                    if (sale.Amount > currentAmount.CurrentAmount)
                    {
                        throw new Exception("Такого кол-ва книг нет на складе"); // TODO: Делаешь BadRequestException, который потом обрабатываешь в 400 ошибку. Сейчас у тебя 500 полетит.
                    }

                    currentAmount.CurrentAmount -= sale.Amount;

                    await _dataContext.Sales.AddAsync(sale, cancellationToken);
                }

                await _dataContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
