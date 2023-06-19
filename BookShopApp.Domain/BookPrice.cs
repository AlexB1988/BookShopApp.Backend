using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain
{
    public class BookPrice
    {
        public Book Book { get; set; }
        public decimal Price { get; set; }
    }
}
