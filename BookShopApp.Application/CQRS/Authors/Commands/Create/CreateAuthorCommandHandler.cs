using AutoMapper;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;

namespace BookShopApp.Application.Authors.Commands.Create
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            //var entity = new Author
            //{
            //    Name = request.Name,
            //    Biography = request.Biography
            //};
            var entity = _mapper.Map<Author>(request);
            await _dataContext.Authors.AddAsync(entity, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
