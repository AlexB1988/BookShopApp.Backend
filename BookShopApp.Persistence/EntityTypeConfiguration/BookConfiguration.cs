using BookShopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders

namespace BookShopApp.Persistence.EntityTypeConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id);
            builder.HasIndex(book => book.Id).IsUnique();
            builder.Property(book => book.Name).HasMaxLength(250);
            builder.HasOne(book => book.Publisher)
                .WithMany(publisher => publisher.Books)
                .HasForeignKey(book => book.PublisherId);
        }
    }
}
