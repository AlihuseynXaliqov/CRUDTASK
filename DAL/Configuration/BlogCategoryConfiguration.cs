using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogsCategories>
    {
        public void Configure(EntityTypeBuilder<BlogsCategories> builder)
        {
            builder.HasOne(c => c.Category)
                .WithMany(bc=>bc.BlogsCategories)
                .HasForeignKey(c=>c.CategoryId);

            builder.HasOne(b => b.Blog)
                .WithMany(bc=>bc.BlogsCategories)
                .HasForeignKey(b=>b.BlogId);

            builder.Ignore(x=>x.IsDeleted);
        }
    }
}
