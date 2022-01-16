namespace Payment.Api.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string ConsumerFullName { get; set; }
        public string ConsumerAddress { get; set; }
    }
}
