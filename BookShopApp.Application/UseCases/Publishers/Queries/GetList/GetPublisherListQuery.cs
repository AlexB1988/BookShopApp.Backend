using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherList
{
    public class GetPublisherListQuery : IRequest<ICollection<PublisherViewModel>>
    {

        private class Handler : IRequestHandler<GetPublisherListQuery, ICollection<PublisherViewModel>>
        {

            private readonly IDataContext _dataContext;

            private readonly IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<ICollection<PublisherViewModel>> Handle(GetPublisherListQuery request, CancellationToken cancellationToken)
            {
                var publishers = await _dataContext.Publishers
                    .ProjectTo<PublisherViewModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return publishers;
            }
        }
    }
}
