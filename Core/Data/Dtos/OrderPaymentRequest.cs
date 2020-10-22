using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos
{
    public class OrderPaymentRequest
    {
        public long OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
