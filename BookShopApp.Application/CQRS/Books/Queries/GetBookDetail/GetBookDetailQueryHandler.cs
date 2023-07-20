using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList;
using BookShopApp.Application.Common.Exceptions;
using BookShopApp.Application.Common.Mappings.DTOs;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBookDetail
{
    public class GetBookDetailQueryHandler : IRequestHandler<GetBookDetailQuery, BookLookupDto>
    {
        public IDataContext _dataContext;
        public IMapper _mapper;

        public GetBookDetailQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<BookLookupDto> Handle(GetBookDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dataContext.Books.FirstOrDefaultAsync(book => book.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            var entityBook = await _dataContext.Books
                .ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(book => book.Id == entity.Id, cancellationToken);

            // TODO: Здесь можно сделать Include, и он подгрузит авторов тоже вместе с книгами. И автомаппер смаппит их тоже, если поставил интерфейс

            var authors = await _dataContext.BookAuthors
                .Where(book => book.BookId == entityBook.Id)
                .Select(author => author.Author)
                .ToListAsync(cancellationToken);

            entityBook.Authors = _mapper.Map<List<AuthorLookupDto>>(authors);

            return entityBook;  
        }
    }
}
