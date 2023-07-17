using AutoMapper;
using BookShopApp.Application.Common.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookShopApp.Application.CQRS.Income.Command.Update
{
    public class UpdateIncomeCommandHandler : IRequestHandler<UpdateIncomeCommand, Unit>
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;
        public UpdateIncomeCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateIncomeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dataContext.Income.FirstOrDefaultAsync(income => income.Id == request.Id,cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(BookIncome), request.Id);
            }

            return Unit.Value;
        }
    }
}
