using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList
{
    public class GetAuthorListQuery : IRequest<ICollection<AuthorViewModel>>
    {

        public class GetAuthorListQueryHandler : IRequestHandler<GetAuthorListQuery, ICollection<AuthorViewModel>>
        {
            private readonly IDataContext _dataContext;

            private readonly IMapper _mapper;

            public GetAuthorListQueryHandler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<ICollection<AuthorViewModel>> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
            {
                var authors = await _dataContext.Authors
                    .ProjectTo<AuthorViewModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return authors;
            }

        }
    }
}
