using E_CommerceSystem.BLL.Servicess.Implementations;
using E_CommerceSystem.DTOs.PaymentDTO;
using E_CommerceSystem.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;
        private readonly UserManager<AppUser> _userManager;

        public PaymentController(PaymentService paymentService, UserManager<AppUser> userManager)
        {
            _paymentService = paymentService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentCreateDTO dto)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized("User not logged in");
            }

            var result = await _paymentService.CreateAsync(dto);
            if (result.Success)
            {
                return Ok(result.Message); 
            }

            return BadRequest(result.Message); 
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var result = await _paymentService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result.Data); 
            }

            return BadRequest(result.Message);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var result = await _paymentService.GetAsync(id);
            if (result.Success)
            {
                return Ok(result.Data); 
            }

            return NotFound(result.Message); 
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, [FromBody] PaymentUpdateDTO dto)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized("User not logged in");
            }

            var result = await _paymentService.UpdateAsync(id, dto);
            if (result.Success)
            {
                return Ok(result.Message); 
            }

            return NotFound(result.Message); 
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized("User not logged in");
            }

            var result = await _paymentService.RemoveAsync(id);
            if (result.Success)
            {
                return Ok(result.Message); 
            }

            return NotFound(result.Message); 
        }
    }
}
