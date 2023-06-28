using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList;
using BookShopApp.Application.Common.Exceptions;
using BookShopApp.Application.Common.Mappings.DTOs;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var entityBook = await _dataContext.Books
                .ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(book=>book.Id==request.Id,cancellationToken);


            var authors = await _dataContext.BookAuthors
                .Where(book => book.BookId == entityBook.Id)
                .Select(author => author.Author)
                .ToListAsync(cancellationToken);
            entityBook.Authors = _mapper.Map<List<AuthorLookupDto>>(authors);

            return entityBook;  
        }
    }
}
