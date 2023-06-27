using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShopApp.Application.Common.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
