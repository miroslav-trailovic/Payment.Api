using System;
using System.ComponentModel.DataAnnotations;

namespace Payment.Api.Models
{
    public class PaymentModel
    {
        [Key]
        public int PaymentId { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }
        public OrderModel Order { get; set; }
    }
}
