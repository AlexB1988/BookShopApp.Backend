using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public BookCurrentAmount Amount { get; set; }
        public ICollection<BookIncome> Income { get; set; }
        public ICollection<BookPrice> Price { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
