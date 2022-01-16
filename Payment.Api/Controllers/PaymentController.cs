using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Payment.Api.Helpers;
using Payment.Api.Services;
using Payment.Api.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Payment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentService _paymentService;

        public PaymentController(ILogger<PaymentController> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentViewModel paymentPost, CancellationToken cancellationToken)
        {
            try
            {
                var isValid = RequestModelValidator.Validate(paymentPost);

                if (!isValid)
                {
                    return BadRequest("Please correct the input data.");
                }

                var paymentToAdd = await _paymentService.CreatePayment(paymentPost, cancellationToken);

                return Created($"payment/{paymentToAdd.PaymentId}", paymentToAdd);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(), ex.Message, paymentPost);

                return BadRequest($"Error occured while creating a payment: {ex.Message}");
            }
        }

        [HttpGet("{paymentId:int}")]
        public async Task<IActionResult> GetPayment([FromRoute] int paymentId)
        {
            try
            {
                var payment = await _paymentService.GetPaymentByPaymentId(paymentId);

                if (payment == null)
                {
                    return NotFound("Payment doesn't exist.");
                }

                return Ok(payment);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(), ex.Message, paymentId);

                return BadRequest($"Error occured while getting a payment: {ex.Message}");
            }
        }
    }
}
