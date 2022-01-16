using System;

namespace Payment.Api.Models
{
    public class PaymentModel
    {
        public int PaymentId { get; set; }
        public DateTime CreationDate { get; set; }
        public uint Amount { get; set; }
        public string CurrencyCode { get; set; }
        public Status Status { get; set; }
        public OrderModel Order { get; set; }
    }
}
