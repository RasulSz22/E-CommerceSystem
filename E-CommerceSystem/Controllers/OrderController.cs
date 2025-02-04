using E_CommerceSystem.BLL.Servicess.Implementations;
using E_CommerceSystem.DTOs.OrderDTO;
using E_CommerceSystem.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(OrderService orderService, UserManager<AppUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDTO dto)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized("User not logged in");
            }

            var result = await _orderService.CreateAsync(dto);
            if (result.Success)
            {
                return Ok(result.Message); 
            }

            return BadRequest(result.Message); 
        }

   
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _orderService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result.Data); 
            }

            return BadRequest(result.Message); 
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var result = await _orderService.GetAsync(id);
            if (result.Success)
            {
                return Ok(result.Data); 
            }

            return NotFound(result.Message); 
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderUpdateDTO dto)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized("User not logged in");
            }

            var result = await _orderService.UpdateAsync(id, dto);
            if (result.Success)
            {
                return Ok(result.Message); 
            }

            return NotFound(result.Message); 
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized("User not logged in");
            }

            var result = await _orderService.RemoveAsync(id);
            if (result.Success)
            {
                return Ok(result.Message); 
            }

            return NotFound(result.Message); 
        }

    }
}
