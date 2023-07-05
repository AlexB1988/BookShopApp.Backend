using BookShopApp.Application.Common.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Books.Commands.Create
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
            if(await _dataContext.Publishers.FirstOrDefaultAsync(publisher => publisher.Id == request.PublisherId) == null)
            {
                throw new NotFoundException(nameof(Publisher), request.PublisherId);
            }

            var entityPublisher = await _dataContext.Publishers.FirstOrDefaultAsync(publisher => publisher.Id == request.PublisherId, cancellationToken);
            var entityBook = new Book
            {
                Name = request.Name,
                Year = request.Year,
                Publisher=entityPublisher
            };

            var entityBookIncome = new BookIncome
            {
                Book=entityBook,
                Amount=request.BookIncomeAmount,
                IncomePrice=request.BookIncomePrice
            };

            var entityCurrentAmount = new BookCurrentAmount
            {
                Book = entityBook,
                CurrentAmount = request.BookIncomeAmount
            };

            var entityPrice = new BookPrice
            {
                Book = entityBook,
                Price = request.CurrentPrice,
                DateBegin = DateTime.UtcNow
            };

            var entitiesAuthors = new List<BookAuthor>();

            //var authorList = await _dataContext.Authors.Select(author=>author.Id).ToListAsync(cancellationToken);
            
            //Проверить на корректность
            //if (request.Authors.Except(authorList).Count !=null)
            //{
            //    throw new NotFoundException(nameof(Author), request.Authors);
            //}

            foreach(var author in request.Authors)
            {
                var entityAuthor = new BookAuthor
                {
                    Book = entityBook,
                    AuthorId = author
                };
                entitiesAuthors.Add(entityAuthor);
            }
            await _dataContext.Books.AddAsync(entityBook,cancellationToken);
            await _dataContext.Income.AddAsync(entityBookIncome,cancellationToken);
            await _dataContext.CurrentAmount.AddAsync(entityCurrentAmount, cancellationToken);
            await _dataContext.Prices.AddAsync(entityPrice, cancellationToken);
            await _dataContext.BookAuthors.AddRangeAsync(entitiesAuthors, cancellationToken);

            await _dataContext.SaveChangesAsync(cancellationToken);

            return entityBook.Id;
        }
    }
}
