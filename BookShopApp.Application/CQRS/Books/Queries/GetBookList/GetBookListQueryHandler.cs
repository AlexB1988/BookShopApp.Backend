using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Common.Mappings.DTOs;
using BookShopApp.Application.Interfaces;
using BookShopApp.Application.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return new BookListViewModel { Books = entityBooks };
        }
    }
}
