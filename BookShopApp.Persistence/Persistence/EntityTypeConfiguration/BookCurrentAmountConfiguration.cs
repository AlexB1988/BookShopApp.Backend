using BookShopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopApp.Infrastructure.Persistence.EntityTypeConfiguration
{
    public class BookCurrentAmountConfiguration : IEntityTypeConfiguration<BookCurrentAmount>
    {
        public void Configure(EntityTypeBuilder<BookCurrentAmount> builder)
        {
            builder.HasKey(amount => new { amount.BookId });
            builder.HasOne(amount => amount.Book)
                .WithOne(book => book.Amount)
                .HasForeignKey<BookCurrentAmount>(amount => amount.BookId);
        }
    }
}
