using BookShopApp.Application.Interfaces;
using BookShopApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IDataContext _dataContext;

        public CreateBookCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var entityBook = new Book
            {
                Name = request.Name,
                Year = request.Year,
                Publisher = request.Publisher,
                BookAmount = request.BookAmount,
                BookPrice = request.BookPrice
            };

            var entityAmount = new BookAmount
            {
                Amount = request.BookAmount.Amount
            };

            var entityPrice = new BookPrice
            {
                Price = request.BookPrice.Price
            };

            var entitiesAuthors = new List<BookAuthor>();

            foreach(var author in request.Authors)
            {
                var entityAuthor = new BookAuthor
                {
                    Book = entityBook,
                    Author = author
                };
                entitiesAuthors.Add(entityAuthor);
            }
            await _dataContext.Books.AddAsync(entityBook,cancellationToken);
            await _dataContext.Amounts.AddAsync(entityAmount,cancellationToken);
            await _dataContext.Prices.AddAsync(entityPrice,cancellationToken);
            await _dataContext.BookAuthors.AddRangeAsync(entitiesAuthors, cancellationToken);

            await _dataContext.SaveChangesAsync(cancellationToken);

            return entityBook.Id;
        }
    }
}
