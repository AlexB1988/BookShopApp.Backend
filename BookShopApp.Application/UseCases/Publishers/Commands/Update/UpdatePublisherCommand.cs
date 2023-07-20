using BookShopApp.Application.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using AutoMapper;
using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Publishers.Commands.Update
{
    public class UpdatePublisherCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public int YearBegin { get; set; }

        private class Handler : IRequestHandler<UpdatePublisherCommand, Unit>
        {

            private readonly IDataContext _dataContext;

            public Handler(IDataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
            {
                var publisher = await _dataContext.Publishers.FirstOrDefaultAsync(publisher => publisher.Id == request.Id, cancellationToken);
                if (publisher == null)
                {
                    throw new NotFoundException(nameof(Publisher), request.Id);
                }

                publisher.Name = request.Name;
                publisher.YearBegin = request.YearBegin;
                publisher.City = request.City;

                await _dataContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
