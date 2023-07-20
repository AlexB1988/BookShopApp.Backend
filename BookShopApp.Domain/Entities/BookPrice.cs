

namespace BookShopApp.Domain.Entities
{
    public class BookPrice
    {
        public int Id { get; set; }
        
        public int BookId { get; set; }
        
        public Book Book { get; set; }
        
        public decimal Price { get; set; }
        
        public DateTime DateBegin { get; set; }
        
        public DateTime? DateEnd { get; set; } = null;
    }
}
