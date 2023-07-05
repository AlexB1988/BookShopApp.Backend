using BookShopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopApp.Persistence.EntityTypeConfiguration
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(publisher => publisher.Id);
            builder.HasIndex(publisher => publisher.Id).IsUnique();
            builder.Property(publisher => publisher.Name).HasMaxLength(100);
        }
    }
}
