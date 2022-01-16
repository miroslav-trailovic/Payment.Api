using System.ComponentModel.DataAnnotations;

namespace Payment.Api.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public string ConsumerFullName { get; set; }
        public string ConsumerAddress { get; set; }
    }
}
