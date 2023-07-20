using BookShopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopApp.Infrastructure.Persistence.EntityTypeConfiguration
{
    public class BookIncomeConfiguration : IEntityTypeConfiguration<BookIncome>
    {
        public void Configure(EntityTypeBuilder<BookIncome> builder)
        {
            builder.HasKey(bookIncome => bookIncome.Id);
            builder.HasIndex(bookIncome => bookIncome.Id).IsUnique();
            builder.HasOne(bookIncome => bookIncome.Book)
                .WithMany(book => book.Incomes)
                .HasForeignKey(bookIncome => bookIncome.BookId);

        }
    }
}
