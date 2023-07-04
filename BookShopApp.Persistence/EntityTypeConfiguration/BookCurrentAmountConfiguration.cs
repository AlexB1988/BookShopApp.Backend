using BookShopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Persistence.EntityTypeConfiguration
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
