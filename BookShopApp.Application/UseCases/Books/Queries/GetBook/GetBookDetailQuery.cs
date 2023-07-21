using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList;
using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Application.Mappings.DTOs;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBookDetail
{
    public class GetBookDetailQuery : IRequest<BookViewModel>
    {
        public int Id { get; set; }

        private class Handler : IRequestHandler<GetBookDetailQuery, BookViewModel>
        {

            public IDataContext _dataContext;

            public IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<BookViewModel> Handle(GetBookDetailQuery request, CancellationToken cancellationToken)
            {

                var book = await _dataContext.Books
                    .ProjectTo<BookViewModel>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(book => book.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Book), request.Id);

                var authors = await _dataContext.BookAuthors
                    .Where(bk => bk.BookId == book.Id)
                    .Select(author => author.Author)
                    .ToListAsync(cancellationToken);

                book.Authors = _mapper.Map<List<AuthorViewModel>>(authors);

                return book;
            }
        }
    }
}
