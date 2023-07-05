using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherList
{
    public class GetPublisherListQueryHandler : IRequestHandler<GetPublisherListQuery, GetPublisherListViewModel>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetPublisherListQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<GetPublisherListViewModel> Handle(GetPublisherListQuery request, CancellationToken cancellationToken)
        {
            var entity =await _dataContext.Publishers
                .ProjectTo<PublisherLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetPublisherListViewModel { Publishers = entity };
        }
    }
}
