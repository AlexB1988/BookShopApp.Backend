using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookShopApp.Application.CQRS.Books.Commands.Update
{
    public class UpdateBookCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public int PublisherId { get; set; }

        public IList<int> Authors { get; set; }

        private class Handler : IRequestHandler<UpdateBookCommand>
        {

            private readonly IDataContext _dataContext;

            public Handler (IDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
            {
                var book = await _dataContext.Books
                    .FirstOrDefaultAsync(book => book.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Book), request.Id);

                book.Name = request.Name;
                book.Year = request.Year;
                book.PublisherId = request.PublisherId;

                var authors = await _dataContext.BookAuthors.Where(book => book.Book.Id == request.Id).ToListAsync(cancellationToken);
                _dataContext.BookAuthors.RemoveRange(authors);

                var entityBookAuthors = new List<BookAuthor>();

                foreach (var author in request.Authors)
                {
                    var bookAuthor = new BookAuthor
                    {
                        Book = book,
                        AuthorId = author
                    };
                    entityBookAuthors.Add(bookAuthor);
                }
                await _dataContext.BookAuthors.AddRangeAsync(entityBookAuthors, cancellationToken);
                await _dataContext.SaveChangesAsync(cancellationToken);

            }
        }
    }
}
