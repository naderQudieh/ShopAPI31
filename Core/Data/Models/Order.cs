using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public short OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPayable { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime UpdatedTime { get; set; }
        public DateTime PaidTime { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public List<OrderPayment> OrderPayments { get; set; }
    }
}
