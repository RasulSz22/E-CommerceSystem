using E_CommerceSystem.BLL.Servicess.Implementations;
using E_CommerceSystem.BLL.Servicess.Interfaces;
using E_CommerceSystem.DTOs.OrderItemDTO;
using E_CommerceSystem.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController (IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderItemGetDTO>>> GetAll()
        {
            var result = await _orderItemService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemGetDTO>> Get(int id)
        {
            var result = await _orderItemService.GetAsync(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Create(OrderItemCreateDTO dto)
        {
            var result = await _orderItemService.CreateAsync(dto);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return CreatedAtAction(nameof(Get), new { id = dto.ProductId }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, OrderItemUpdateDTO dto)
        {
            var result = await _orderItemService.UpdateAsync(id, dto);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _orderItemService.RemoveAsync(id);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return NoContent();
        }

    }
}
