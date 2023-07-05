using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CommandsQueries.Authors.Queries.GetAuthorList
{
    public class GetAuthorListQueryHandler:IRequestHandler<GetAuthorListQuery,AuthorListViewModel>
    {
        private readonly IDataContext _dataContext;

        private readonly IMapper _mapper;

        public GetAuthorListQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<AuthorListViewModel> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
        {
            var authorsQuery= await _dataContext.Authors.ProjectTo<AuthorLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new AuthorListViewModel { Authors= authorsQuery };
        }

    }
}
