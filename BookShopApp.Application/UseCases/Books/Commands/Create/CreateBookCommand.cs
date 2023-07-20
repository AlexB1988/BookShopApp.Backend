using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Books.Commands.Create
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public int PublisherId { get; set; }

        public int BookIncomeAmount { get; set; }

        public decimal BookIncomePrice { get; set; }

        public decimal CurrentPrice { get; set; }

        public ICollection<int> Authors { get; set; }

        private class Handler : IRequestHandler<CreateBookCommand, int>
        {

            private readonly IDataContext _dataContext;

            public Handler(IDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
            { 

                var publisher = await _dataContext.Publishers
                    .FirstOrDefaultAsync(publisher => publisher.Id == request.PublisherId, cancellationToken)
                    ?? throw new NotFoundException(nameof(Publisher),request.PublisherId);

                var book = new Book
                {
                    Name = request.Name,
                    Year = request.Year,
                    Publisher = publisher,
                    Incomes = new List<BookIncome> 
                    { 
                        new BookIncome
                        {  
                            Amount = request.BookIncomeAmount,
                            IncomePrice = request.BookIncomePrice
                        } 
                    },
                    Amount = new BookCurrentAmount { CurrentAmount = request.BookIncomeAmount},
                    Prices = new List<BookPrice>
                    {
                        new BookPrice
                        {
                            Price = request.CurrentPrice,
                            DateBegin = DateTime.UtcNow
                        }
                    }
                };

                book.BookAuthors = new List<BookAuthor>();

                foreach (var authorId in request.Authors)
                {
                    var author = new BookAuthor
                    {
                        Book = book,
                        AuthorId = authorId
                    };
                    book.BookAuthors.Add(author);
                }


                await _dataContext.Books.AddAsync(book, cancellationToken);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return book.Id;

            }
        }
    }
}