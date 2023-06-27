using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain
{
    public class Publisher:BaseEntity
    {
        public string City { get; set; }
        public int YearBegin { get; set; }
        public ICollection<Book> Books { get; set;}
    }
}
