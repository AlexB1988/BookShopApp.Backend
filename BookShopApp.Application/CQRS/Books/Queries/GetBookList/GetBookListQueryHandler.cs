using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList;
using BookShopApp.Application.Common.Mappings.DTOs;
using BookShopApp.Application.Interfaces;
using BookShopApp.Application.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBookList
{
    public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, BookListViewModel>
    {
        public IDataContext _dataContext;
        public IMapper _mapper;

        public GetBookListQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<BookListViewModel> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var entityBooks = await _dataContext.Books
                .ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            
            foreach(var entityBook in entityBooks)
            {
                var authors =await _dataContext.BookAuthors
                    .Where(book => book.BookId == entityBook.Id)
                    .Select(author => author.Author)
                    .ToListAsync(cancellationToken);
                entityBook.Authors = _mapper.Map<List<AuthorLookupDto>>(authors);
            }

            return new BookListViewModel { Books = entityBooks };
        }
    }
}
