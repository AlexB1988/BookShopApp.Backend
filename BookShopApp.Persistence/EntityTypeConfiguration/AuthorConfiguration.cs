using BookShopApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Persistence.EntityTypeConfiguration
{
    // TODO: Так правильно, но мы пишем конфигураторы в файлах сущностей. Да, нарушение, но так удобнее и понятно сразу, что к чему, можно закрыть глаза.
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
