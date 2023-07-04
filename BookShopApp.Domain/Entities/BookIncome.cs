

namespace BookShopApp.Domain.Entities
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
