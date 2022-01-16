using Microsoft.EntityFrameworkCore;
using Payment.Api.Data;
using Payment.Api.Models;
using Payment.Api.ViewModels;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Payment.Api.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentContext _dbContext;

        public PaymentService(PaymentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaymentModel> CreatePayment(CreatePaymentViewModel paymentPost, CancellationToken cancellationToken)
        {
            var paymentToAdd = new PaymentModel
            {
                CreationDate = DateTime.Now,
                Amount = paymentPost.Amount,
                CurrencyCode = paymentPost.CurrencyCode,
                Status = paymentPost.Status,
                Order = new OrderModel
                {
                    ConsumerFullName = paymentPost.ConsumerFullName,
                    ConsumerAddress = paymentPost.ConsumerAddress
                }
            };

            await _dbContext.Payments.AddAsync(paymentToAdd, cancellationToken);
            await _dbContext.SaveChangesAsync();

            return paymentToAdd;
        }

        public async Task<PaymentModel> GetPaymentByPaymentId(int paymentId)
        {
            var payment = await Task.Run(() => _dbContext.Payments.Include(p => p.Order)
                    .FirstOrDefault(e => e.PaymentId == paymentId));

            return payment;
        }
    }
}
