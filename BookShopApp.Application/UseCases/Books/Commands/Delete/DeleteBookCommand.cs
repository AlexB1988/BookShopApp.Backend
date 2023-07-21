using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Books.Commands.Delete
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }

        private class Handler: IRequestHandler<DeleteBookCommand>
        {

            private readonly IDataContext _dataContext;

            public Handler (IDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
            {

                var book = await _dataContext.Books
                    .FirstOrDefaultAsync(book => book.Id == request.Id 
                            && book.Sales.Count==0, cancellationToken)
                    ?? throw new BadRequestException("книги не существует, либо по данной книге есть продажи");

                _dataContext.Books.Remove(book);
                await _dataContext.SaveChangesAsync(cancellationToken);

            }
        }
    }
}
