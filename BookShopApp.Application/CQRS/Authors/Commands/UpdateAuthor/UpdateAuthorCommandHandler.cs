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

namespace BookShopApp.Application.CQRS.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand,Unit>
    {
        private readonly IDataContext _dataContext;

        public UpdateAuthorCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity =await _dataContext.Authors.FirstOrDefaultAsync(author => author.Id == request.Id,cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            entity.Name = request.Name;
            entity.Biography= request.Biography;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
