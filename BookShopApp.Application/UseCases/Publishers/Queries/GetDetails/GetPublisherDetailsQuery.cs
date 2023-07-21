using AutoMapper;
using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Publishers.Queries.GetPublisherDetails
{
    public class GetPublisherDetailsQuery : IRequest<PublisherDetailsViewModel>
    {
        public int Id { get; set; }

        private class Handler : IRequestHandler<GetPublisherDetailsQuery, PublisherDetailsViewModel>
        {

            private readonly IDataContext _dataContext;

            private readonly IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }
            public async Task<PublisherDetailsViewModel> Handle(GetPublisherDetailsQuery request, CancellationToken cancellationToken)
            {
                var publisher = await _dataContext.Publishers
                    .FirstOrDefaultAsync(publisher => publisher.Id == request.Id)
                    ?? throw new NotFoundException(nameof(Publisher), request.Id);

                return _mapper.Map<PublisherDetailsViewModel>(publisher);
            }
        }
    }
}
