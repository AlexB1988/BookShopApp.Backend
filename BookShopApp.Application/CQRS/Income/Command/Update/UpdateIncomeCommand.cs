using BookShopApp.Application.Common.Mappings;
using BookShopApp.Domain.Entities;
using MediatR;
using Newtonsoft.Json;

namespace BookShopApp.Application.CQRS.Income.Command.Update
{
    public class UpdateIncomeCommand : IRequest<Unit>, IMapWith<BookIncome>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Amount { get; set; }
        public decimal IncomePrice { get; set; }
    }
}
