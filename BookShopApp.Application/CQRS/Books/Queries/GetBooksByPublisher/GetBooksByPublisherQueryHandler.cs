using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Common.Exceptions;
using BookShopApp.Application.Common.Mappings.DTOs;
using BookShopApp.Application.Interfaces;
using BookShopApp.Application.ViewModels;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Books.Queries.GetBooksByPublisher
{
    public class GetBooksByPublisherQueryHandler : IRequestHandler<GetBooksByPublisherQuery, BookListViewModel>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetBooksByPublisherQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<BookListViewModel> Handle(GetBooksByPublisherQuery request, CancellationToken cancellationToken)
        {
            var entityBooks = await _dataContext.Books
                .Where(book => book.PublisherId == request.PublisherId)
                .ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (entityBooks == null)
            {
                throw new NotFoundException(nameof(Book), request.PublisherId);
            }

            return new BookListViewModel { Books = entityBooks };
        }
    }
}
