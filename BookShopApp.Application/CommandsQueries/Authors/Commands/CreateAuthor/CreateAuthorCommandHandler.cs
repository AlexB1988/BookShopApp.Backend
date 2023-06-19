using BookShopApp.Application.Interfaces;
using BookShopApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.Authors.Commands.CreateAuthor
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
            var author = new Author
            {
                Name = request.Name
            };
            await _dataContext.Authors.AddAsync(author, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return author.Id;
        }
    }
}
