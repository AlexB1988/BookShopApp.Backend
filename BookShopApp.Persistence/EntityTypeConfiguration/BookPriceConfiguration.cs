﻿using BookShopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShopApp.Persistence.EntityTypeConfiguration
{
    public class BookPriceConfiguration : IEntityTypeConfiguration<BookPrice>
    {
        public void Configure(EntityTypeBuilder<BookPrice> builder)
        {
            builder.HasKey(bookPrice => bookPrice.Id);
            builder.HasIndex(bookPrice=>bookPrice.Id).IsUnique();
            builder.HasOne(bookPrice => bookPrice.Book)
                .WithMany(book => book.Price)
                .HasForeignKey(bookPrice => bookPrice.BookId);
        }
    }
}
