using AutoMapper;
using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookShopApp.Application.CQRS.Authors.Commands.Update
{
    public class UpdateAuthorCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Biography { get; set; }

        private class Handler : IRequestHandler<UpdateAuthorCommand, Unit>
        {

            private readonly IDataContext _dataContext;

            private readonly IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
            {
                var author = await _dataContext.Authors.FirstOrDefaultAsync(author => author.Id == request.Id, cancellationToken);

                if (author == null)
                {
                    throw new NotFoundException(nameof(Author), request.Id);
                }

                author.Name = request.Name;
                author.Biography = request.Biography;

                await _dataContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
