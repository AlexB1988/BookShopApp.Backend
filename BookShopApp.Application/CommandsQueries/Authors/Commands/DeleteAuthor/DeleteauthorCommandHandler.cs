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

namespace BookShopApp.Application.CommandsQueries.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand,Unit>
    {
        private readonly IDataContext _dataContext;
        public DeleteAuthorCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _dataContext.Authors.FindAsync(new object[] { request.Id }, cancellationToken);

            if (author == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            _dataContext.Authors.Remove(author);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
