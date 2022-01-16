using Microsoft.EntityFrameworkCore;
using Payment.Api.Models;

namespace Payment.Api.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {
        }

        public DbSet<PaymentModel> Payments { get; set; }
    }
}
