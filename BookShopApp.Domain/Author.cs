using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain
{
    public class Author:BaseEntity
    {
        public string Biography { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
