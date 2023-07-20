using AutoMapper;
using BookShopApp.Application.Interfaces;
using BookShopApp.Application.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;

namespace BookShopApp.Application.CQRS.Publishers.Commands.Create
{
    public class CreatePublisherCommand : IRequest<int>, IMapWith<Publisher>
    {
        public string Name { get; set; }

        public string City { get; set; }

        public int YearBegin { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePublisherCommand, Publisher>()
                .ForMember(publisher => publisher.Name,
                    opt => opt.MapFrom(publisherCreate => publisherCreate.Name))
                .ForMember(publisher => publisher.City,
                    opt => opt.MapFrom(publisherCreate => publisherCreate.City))
                .ForMember(publisher => publisher.YearBegin,
                    opt => opt.MapFrom(publisherCreate => publisherCreate.YearBegin));
        }

        private class Handler : IRequestHandler<CreatePublisherCommand, int>
        {

            private readonly IDataContext _dataContext;

            private readonly IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
            {
                var publisher = _mapper.Map<Publisher>(request);

                await _dataContext.Publishers.AddAsync(publisher, cancellationToken);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return publisher.Id;
            }
        }
    }
}
