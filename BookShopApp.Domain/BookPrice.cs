﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Domain
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
