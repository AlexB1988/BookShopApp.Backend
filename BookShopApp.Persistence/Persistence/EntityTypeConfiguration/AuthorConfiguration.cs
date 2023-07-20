using BookShopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopApp.Infrastructure.Persistence.EntityTypeConfiguration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(author => author.Id);
            builder.HasIndex(author => author.Id).IsUnique();
            builder.Property(author => author.Name).HasMaxLength(100);
        }
    }
}
