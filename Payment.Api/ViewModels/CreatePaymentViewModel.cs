using Payment.Api.Models;
using System;

namespace Payment.Api.ViewModels
{
    public class CreatePaymentViewModel
    {
        public DateTime CreationDate { get; set; }
        public uint Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }
        public string ConsumerFullName { get; set; }
        public string ConsumerAddress { get; set; }
    }
}
