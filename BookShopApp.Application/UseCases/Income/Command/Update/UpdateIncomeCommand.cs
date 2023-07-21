using AutoMapper;
using BookShopApp.Application.Exceptions;
using BookShopApp.Application.Interfaces;
using BookShopApp.Application.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookShopApp.Application.CQRS.Income.Command.Update
{
    public class UpdateIncomeCommand : IRequest, IMapWith<BookIncome>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public int BookId { get; set; }

        public int Amount { get; set; }

        public decimal IncomePrice { get; set; }

        private class Handler : IRequestHandler<UpdateIncomeCommand>
        {

            private readonly IDataContext _dataContext;

            private readonly IMapper _mapper;

            public Handler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task Handle(UpdateIncomeCommand request, CancellationToken cancellationToken)
            {
                var income = await _dataContext.Income
                    .FirstOrDefaultAsync(income => income.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(BookIncome), request.Id);

            }
        }
    }
}
