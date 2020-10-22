using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(_ => _.Name).IsRequired();
            builder.Property(_ => _.Price).IsRequired();

            builder.HasData(new Product() { Id = 1, Name = "Cola Cola", Price = 200.0M });
            builder.HasData(new Product() { Id = 2, Name = "7 Up", Price = 200.0M });
            builder.HasData(new Product() { Id = 3, Name = "Ice Cream", Price = 1000.0M });
            builder.HasData(new Product() { Id = 4, Name = "Ice Cream", Price = 2000.0M });
            builder.HasData(new Product() { Id = 5, Name = "Vegitables", Price = 5000.0M });
        }
    }
}
