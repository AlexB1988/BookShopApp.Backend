using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.CQRS.Income.Query
{
    public class GetIncomesOfBookViewModel
    {
        public IList<GetIncomeOfBookLookupDto> Incomes { get; set; }
    }
}
