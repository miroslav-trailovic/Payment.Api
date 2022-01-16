using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Payment.Api.Data;
using Payment.Api.Models;
using Payment.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Payment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly PaymentContext _dbContext;

        public PaymentController(ILogger<PaymentController> logger, PaymentContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentViewModel paymentPost, CancellationToken cancellationToken)
        {
            try
            {
                var paymentToAdd = new PaymentModel
                {
                    CreationDate = paymentPost.CreationDate,
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

                return Created($"payment/{paymentToAdd.PaymentId}", paymentToAdd);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(), ex.Message, paymentPost);

                return BadRequest($"Error occured while creating a payment: {ex.Message}");
            }
        }

        [HttpGet("{paymentId:int}")]
        public async Task<IActionResult> GetPaymentByPaymentId([FromRoute] int paymentId)
        {
            try
            {
                var payment = await Task.Run(() => _dbContext.Payments.Include(p => p.Order)
                    .FirstOrDefault(e => e.PaymentId == paymentId));

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
