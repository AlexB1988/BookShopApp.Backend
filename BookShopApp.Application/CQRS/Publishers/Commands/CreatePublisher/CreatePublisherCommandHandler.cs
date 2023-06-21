using BookShopApp.Application.Interfaces;
using BookShopApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Publishers.Commands.CreatePublisher
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
            var publisher = new Publisher
            {
                Name = request.Name
            };
            await _dataContext.Publishers.AddAsync(publisher, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return publisher.Id;
        }
    }
}
