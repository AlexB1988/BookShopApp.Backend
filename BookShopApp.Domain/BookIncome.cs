using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain
{
    public class BookIncome
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Amount { get; set; }
        public decimal IncomePrice { get; set; }
        public DateTime DateIncome { get; set; } = DateTime.UtcNow;
    }
}
