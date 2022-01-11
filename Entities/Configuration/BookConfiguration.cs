using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {   
        //Data Entries via migration
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book
                {
                    BookId = 1,
                    BookName = "Harry Potter",
                    Author = "J k Rowlings",
                    NoOfBooks = 15,
                    CategoryId = 1,
                    ImageAddress = ""
                },
                new Book
                {
                    BookId = 2,
                    BookName = "Indian History",
                    Author = "Abcd",
                    NoOfBooks = 15,
                    CategoryId = 2,
                    ImageAddress = ""
                },
                new Book
                {
                    BookId = 3,
                    BookName = "Indian Locations",
                    Author= "Abcd",
                    NoOfBooks = 15,
                    CategoryId = 3,
                    ImageAddress = ""
                }
            );
        }
    }
}
