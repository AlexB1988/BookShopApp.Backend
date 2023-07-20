using BookShopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopApp.Infrastructure.Persistence.EntityTypeConfiguration
{
    public class SalesConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(sale => sale.Id);
            builder.HasIndex(sale => sale.Id).IsUnique();
            builder.HasOne(sales => sales.Book)
                .WithMany(book => book.Sales)
                .HasForeignKey(book => book.BookId);
        }
    }
}
