using BookShopApp.Application.Common.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IDataContext _dataContext;

        public UpdateBookCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var entityBook = await _dataContext.Books.FirstOrDefaultAsync(book => book.Id == request.Id,cancellationToken);
            if (entityBook == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }
            entityBook.Name = request.Name;
            entityBook.Year=request.Year;
            entityBook.PublisherId=request.PublisherId;
            var authorsBook = await _dataContext.BookAuthors.Where(book => book.Book.Id == request.Id).ToListAsync(cancellationToken);
            _dataContext.BookAuthors.RemoveRange(authorsBook);

            var entityBookAuthors=new List<BookAuthor>();
            
            foreach(var author in request.Authors)
            {
                var bookAuthor = new BookAuthor
                {
                    Book = entityBook,
                    AuthorId = author
                };
                entityBookAuthors.Add(bookAuthor);
            }
            await _dataContext.BookAuthors.AddRangeAsync(entityBookAuthors,cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
