using Payment.Api.Models;
using Payment.Api.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace Payment.Api.Services
{
    public interface IPaymentService
    {
        Task<PaymentModel> CreatePayment(CreatePaymentViewModel paymentPost, CancellationToken cancellationToken);
        Task<PaymentModel> GetPaymentByPaymentId(int paymentId);
    }
}
