

namespace BookShopApp.Application.CQRS.Income.Query
{
    public class GetIncomesOfBookViewModel
    {
        public IList<GetIncomeOfBookLookupDto> Incomes { get; set; }
    }
}
