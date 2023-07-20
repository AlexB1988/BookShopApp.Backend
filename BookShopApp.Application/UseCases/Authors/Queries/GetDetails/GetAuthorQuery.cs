using AutoMapper;
using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorBiography
{
    public class GetAuthorQuery : IRequest<AuthorViewModel>
    {
        public int Id { get; set; }

        private class Handler : IRequestHandler<GetAuthorQuery, AuthorViewModel>
        {
            private readonly IDataContext _dataContext;
            private readonly IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<AuthorViewModel> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
            {
                var author = await _dataContext.Authors.FirstOrDefaultAsync(author => author.Id == request.Id);

                if (author == null)
                {
                    throw new NotFoundException(nameof(Author), request.Id);
                }

                return _mapper.Map<AuthorViewModel>(author);
            }
        }
    }
}
