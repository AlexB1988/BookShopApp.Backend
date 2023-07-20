using AutoMapper;
using BookShopApp.Application.Interfaces;
using BookShopApp.Application.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;

namespace BookShopApp.Application.Authors.Commands.Create
{
    public class CreateAuthorCommand : IRequest<int>, IMapWith<Author>
    {
        public string Name { get; set; }

        public string Biography { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAuthorCommand, Author>()
                .ForMember(author => author.Name,
                    opt => opt.MapFrom(authorCommand => authorCommand.Name))
                .ForMember(author => author.Biography,
                    opt => opt.MapFrom(authorCommand => authorCommand.Biography));
        }

        private class Handler : IRequestHandler<CreateAuthorCommand, int>
        {
            private readonly IDataContext _dataContext;

            private readonly IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
            {
                var author = _mapper.Map<Author>(request);
                await _dataContext.Authors.AddAsync(author, cancellationToken);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return author.Id;
            }
        }
    }
}