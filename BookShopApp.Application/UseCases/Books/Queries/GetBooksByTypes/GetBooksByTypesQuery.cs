using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Application.Mappings.DTOs;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBooksByAuthor
{
    public class GetBooksByAuthorQuery : IRequest<ICollection<BookViewModel>>
    {
        public int? AuthorId { get; set; }

        public string? Name { get; set; }

        public int? PublisherId { get; set; }

        private class Handler : IRequestHandler<GetBooksByAuthorQuery, ICollection<BookViewModel>>
        {

            public IDataContext _dataContext;

            public IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<ICollection<BookViewModel>> Handle(GetBooksByAuthorQuery request, CancellationToken cancellationToken)
            {

                var books = await _dataContext.Books
                        .Where(book => book.PublisherId == request.PublisherId 
                            || book.Name.Contains(request.Name)
                            || book.BookAuthors.Any(author => author.AuthorId == request.AuthorId))
                        .ProjectTo<BookViewModel>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                        ?? throw new NotFoundException(nameof(Book), "Книг не найдено");

                return books;
            }
        }
    }
}
