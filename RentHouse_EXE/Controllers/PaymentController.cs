using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Controllers
{
    [ApiController]
    [Route("payment")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateZaloPayRequest(decimal amount)
        {
            try
            {
                return Ok(await _paymentService.CreateZaloPayRequest(amount));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }   
    }
}
