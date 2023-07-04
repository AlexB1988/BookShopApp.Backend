

namespace BookShopApp.Domain.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int YearBegin { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
