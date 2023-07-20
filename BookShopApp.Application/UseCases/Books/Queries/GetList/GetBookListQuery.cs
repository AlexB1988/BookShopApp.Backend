using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList;
using BookShopApp.Application.Interfaces;
using BookShopApp.Application.Mappings.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBookList
{
    public class GetBookListQuery : IRequest<ICollection<BookViewModel>>
    {

        private class Handler : IRequestHandler<GetBookListQuery, ICollection<BookViewModel>>
        {
            public IDataContext _dataContext;

            public IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<ICollection<BookViewModel>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
            {
                var book = await _dataContext.Books
                    .ProjectTo<BookViewModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                foreach (var entityBook in book)
                {
                    var authors = await _dataContext.BookAuthors
                        .Where(book => book.BookId == entityBook.Id)
                        .Select(author => author.Author)
                        .ToListAsync(cancellationToken);
                    entityBook.Authors = _mapper.Map<List<AuthorViewModel>>(authors);
                }

                return book;
            }
        }
    }
}