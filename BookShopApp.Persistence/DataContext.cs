using BookShopApp.Application.Interfaces;
using BookShopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookShopApp.Persistence
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Book> Books { get; set; } 
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookPrice> Prices {get;set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookIncome> Income {get;set; }
        public DbSet<BookCurrentAmount> CurrentAmount { get;set; }
        public DbSet<Sale> Sales { get; set; }
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
