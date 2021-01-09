using Ecommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Property(p => p.ImageUrl).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne<Category>(ı => ı.Category).WithMany(ı => ı.Products).HasForeignKey(ı => ı.CategoryId);
            builder.ToTable("Products");

        }
    }
}
