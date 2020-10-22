using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(_=>_.OrderItems).WithOne(_=>_.Order);
            builder.HasMany(_=>_.OrderPayments).WithOne(_=>_.Order);
        }
    }
}
