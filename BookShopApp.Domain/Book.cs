using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain
{
    public class Book:BaseEntity
    {
        public Publisher Publisher { get; set; }
        public BookAmount BookAmount { get; set; }
        public BookPrice BookPrice { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
