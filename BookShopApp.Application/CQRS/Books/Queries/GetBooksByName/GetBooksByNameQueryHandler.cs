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

namespace BookShopApp.Application.CQRS.Books.Queries.GetBooksByName
{
    public class GetBooksByNameQueryHandler : IRequestHandler<GetBooksByNameQuery, BookListViewModel>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;
        public GetBooksByNameQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<BookListViewModel> Handle(GetBooksByNameQuery request, CancellationToken cancellationToken)
        {
            var entityBooks =await _dataContext.Books
                .Where(book => book.Name.Contains(request.Name))
                .ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (entityBooks == null)
            {
                throw new NotFoundException(nameof(Book), request.Name);
            }

            return new BookListViewModel { Books=entityBooks };
        }
    }
}
