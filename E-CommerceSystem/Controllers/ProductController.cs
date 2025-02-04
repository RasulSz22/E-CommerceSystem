using E_CommerceSystem.BLL.Servicess.Implementations;
using E_CommerceSystem.BLL.Servicess.Interfaces;
using E_CommerceSystem.DAL.Context;
using E_CommerceSystem.DTOs.ProductDTO;
using E_CommerceSystem.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ECommerceSystemContex _context;

        public ProductController(IProductService productService, UserManager<AppUser> userManager, ECommerceSystemContex context)
        {
            _productService = productService;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllAsync();
            if (products == null)
            {
                return NotFound(new { Message = "No products found." });
            }
            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _productService.GetAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(new { Message = result.Message });
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] ProductCreateDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productService.CreateAsync(productDto);

            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id,[FromForm] ProductUpdateDTO productDto)
        {
            var result = await _productService.UpdateAsync(id, productDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.RemoveAsync(id);
            if (result.Success)
            {
                return NoContent();
            }
            return NotFound(new { Message = "Product not found." });
        }
    }
}
