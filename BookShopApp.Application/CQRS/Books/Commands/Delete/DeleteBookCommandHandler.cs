using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Books.Commands.Delete
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IDataContext _dataContext;

        public DeleteBookCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            //Добработать запрет на удаление книг с историей
            var entityPrice = await _dataContext.Prices.Where(price => price.Book.Id == request.Id).ToListAsync(cancellationToken);
            var entityAmount= await _dataContext.CurrentAmount.FirstOrDefaultAsync(amount=>amount.Book.Id == request.Id,cancellationToken);
            var entityAuthors = await _dataContext.BookAuthors.Where(book => book.Book.Id == request.Id).ToListAsync(cancellationToken);
            var entityBook = await _dataContext.Books.FirstOrDefaultAsync(book => book.Id == request.Id, cancellationToken);
            var entityIncome = await _dataContext.Income.Where(income => income.BookId == request.Id).ToListAsync(cancellationToken);

             _dataContext.Prices.RemoveRange(entityPrice);
            _dataContext.CurrentAmount.Remove(entityAmount);
            _dataContext.BookAuthors.RemoveRange(entityAuthors);
            _dataContext.Income.RemoveRange(entityIncome);
            _dataContext.Books.Remove(entityBook);

            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
