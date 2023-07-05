using MediatR;

namespace BookShopApp.Application.CQRS.Income.Create
{
    public class CreateIncomeCommand:IRequest<int>
    {
        public int BookId { get; set; }
        public int Amount { get; set; }
        public decimal IncomePrice { get; set; }
    }
}
