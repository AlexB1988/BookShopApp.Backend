using AutoMapper;
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
            var entity =await _dataContext.Books.FirstOrDefaultAsync(book => book.Id == request.Id,cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            var result= _mapper.Map<BookLookupDto>(entity);
            //result.Authors = await _dataContext.Authors
            //    .Include(author => author.BookAuthors.Where(book => book.BookId == request.Id))
            //    .Select(author => author.Name)
            //    .ToListAsync(cancellationToken);

            return result;  
        }
    }
}
