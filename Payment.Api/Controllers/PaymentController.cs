using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Payment.Api.Models;
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
        public PaymentController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody]PaymentModel paymentPost, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return Created(string.Empty, new PaymentModel());
        }

        [HttpGet("{paymentId:int}")]
        public async Task<IActionResult> GetPaymentByPaymentId([FromRoute]int paymentId, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return Ok("GetPayment is fine.");
        }
    }
}
