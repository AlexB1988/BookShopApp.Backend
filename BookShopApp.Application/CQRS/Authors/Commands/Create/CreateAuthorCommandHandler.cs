using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;

namespace BookShopApp.Application.Authors.Commands.Create
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IDataContext _dataContext;

        public CreateAuthorCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = new Author
            {
                Name = request.Name,
                Biography = request.Biography
            };
            await _dataContext.Authors.AddAsync(entity, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
