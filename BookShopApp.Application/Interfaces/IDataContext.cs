using BookShopApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Application.Interfaces
{
    public interface IDataContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Publisher> Publishers { get; set; }
        DbSet<BookPrice> Prices { get; set; }
        DbSet<BookAuthor> BookAuthors { get; set; }
        DbSet<BookIncome> Income { get; set; }
        DbSet<BookCurrentAmount> CurrentAmount { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
