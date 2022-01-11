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
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        //Data Entries via migration
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
            (
            new Category
            {
                CategoryId = 1,
                CategoryName = "Fiction"
            },
            new Category
            {
                CategoryId = 2,
                CategoryName = "History"
            },
            new Category
            {
                CategoryId = 3,
                CategoryName = "Science"
            },
            new Category
            {
                CategoryId = 4,
                CategoryName = "Geography"
            }
            );
        }
    }
}
