using BookShopApp.Application.Interfaces;
using BookShopApp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Books.Commands.DeleteBook
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
            var entityPrice = await _dataContext.Prices.FirstOrDefaultAsync(price => price.Book.Id == request.Id,cancellationToken);
            var entityAmount= await _dataContext.Amounts.FirstOrDefaultAsync(amount=>amount.Book.Id == request.Id,cancellationToken);
            var entityAuthors = await _dataContext.BookAuthors.Where(book => book.Book.Id == request.Id).ToListAsync(cancellationToken);
            var entityBook = await _dataContext.Books.FirstOrDefaultAsync(book => book.Id == request.Id, cancellationToken);

             _dataContext.Prices.Remove(entityPrice);
            _dataContext.Amounts.Remove(entityAmount);
            _dataContext.BookAuthors.RemoveRange(entityAuthors);
            _dataContext.Books.Remove(entityBook);

            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
