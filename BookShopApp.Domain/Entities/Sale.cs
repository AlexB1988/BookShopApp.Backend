

namespace BookShopApp.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Amount { get; set; }
    }
}
