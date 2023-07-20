using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Books.Commands.Delete
{
    public class DeleteBookCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        private class Handler: IRequestHandler<DeleteBookCommand, Unit>
        {

            private readonly IDataContext _dataContext;

            public Handler (IDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
            {
                var IsSoldBook = await _dataContext.Sales.AnyAsync(book => book.BookId == request.Id);

                if (IsSoldBook)
                {
                    throw new Exception("По данной книге есть продажи");
                }

                var book = await _dataContext.Books.FirstOrDefaultAsync(book => book.Id == request.Id, cancellationToken);

                _dataContext.Books.Remove(book);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
