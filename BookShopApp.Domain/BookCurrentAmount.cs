using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain
{
    public class BookCurrentAmount
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int CurrentAmount { get; set; }
    }
}
