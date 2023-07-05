using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;

namespace BookShopApp.Application.CQRS.Publishers.Commands.Create
{
    public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommand, int>
    {
        private readonly IDataContext _dataContext;

        public CreatePublisherCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
        {
            var entity = new Publisher
            {
                Name = request.Name,
                City= request.City,
                YearBegin= request.YearBegin
            };
            await _dataContext.Publishers.AddAsync(entity, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
