using BookShopApp.Application.Interfaces;
using BookShopApp.Domain;
using BookShopApp.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // TODO: Здесь можно обойтись одной строкой, нужно просто указать сборку, в которой хранятся конфигураторы.
            // builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); Берет из текущей сборки, тк конфиги у тебя находятся в этом же прожекте
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new PublisherConfiguration());
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new BookIncomeConfiguration());
            builder.ApplyConfiguration(new BookCurrentAmountConfiguration());
            builder.ApplyConfiguration(new BookPriceConfiguration());
            builder.ApplyConfiguration(new BookAuthorConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
