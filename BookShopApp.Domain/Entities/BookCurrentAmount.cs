

namespace BookShopApp.Domain.Entities
{
    public class BookCurrentAmount
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int CurrentAmount { get; set; }
    }
}
