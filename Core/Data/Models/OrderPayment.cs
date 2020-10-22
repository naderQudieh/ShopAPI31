using System;

namespace Core.Models
{
    public class OrderPayment
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentTime { get; set; }
        public string PaymentMethod { get; set; }
    }
}
