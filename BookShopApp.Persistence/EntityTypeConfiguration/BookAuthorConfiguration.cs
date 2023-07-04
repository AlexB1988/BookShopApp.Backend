using BookShopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Persistence.EntityTypeConfiguration
{
    public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(bookAuthor => new { bookAuthor.BookId, bookAuthor.AuthorId });
            builder.HasOne(bookAuthor => bookAuthor.Book)
                .WithMany(bookAuthor => bookAuthor.BookAuthors)
                .HasForeignKey(bookAuthor => bookAuthor.BookId);
            builder.HasOne(bookAuthor => bookAuthor.Author)
                .WithMany(bookAuthor => bookAuthor.BookAuthors)
                .HasForeignKey(bookAuthor => bookAuthor.AuthorId);
        }
    }
}
