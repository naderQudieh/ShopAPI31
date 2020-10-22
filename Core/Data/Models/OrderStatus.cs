using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class OrderStatus
    {
        public short Id { get; set; }
        public string Name { get; set; }
    }

    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasData(new OrderStatus() { Id = 1, Name = "Pending" });
            builder.HasData(new OrderStatus() { Id = 2, Name = "Paid" });
        }
    }

}
