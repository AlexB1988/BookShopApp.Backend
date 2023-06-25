using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Common.Exceptions;
using BookShopApp.Application.Common.Mappings.DTOs;
using BookShopApp.Application.Interfaces;
using BookShopApp.Application.ViewModels;
using BookShopApp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBooksByAuthor
{
    public class GetBooksByAuthorQueryHandler : IRequestHandler<GetBooksByAuthorQuery, BookListViewModel>
    {
        public IDataContext _dataContext;
        public IMapper _mapper;
        public GetBooksByAuthorQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<BookListViewModel> Handle(GetBooksByAuthorQuery request, CancellationToken cancellationToken)
        {
            var entityBooks =await _dataContext.Books
                    .Include(book=>book.BookAuthors.Where(author=>author.AuthorId==request.AuthorId))
                    .ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            if (entityBooks == null)
            {
                throw new NotFoundException(nameof(Author), request.AuthorId);
            }

            return new BookListViewModel { Books=entityBooks};
        }
    }
}
