using AutoMapper;
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

namespace BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherDetails
{
    public class GetPublisherDetailsQueryHandler : IRequestHandler<GetPublisherDetailsQuery, PublisherDetailsViewModel>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetPublisherDetailsQueryHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<PublisherDetailsViewModel> Handle(GetPublisherDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dataContext.Publishers.FirstOrDefaultAsync(publisher => publisher.Id == request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Publisher),request.Id);
            }

            return _mapper.Map<PublisherDetailsViewModel>(entity);
        }
    }
}
