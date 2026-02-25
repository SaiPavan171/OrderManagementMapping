using Microsoft.AspNetCore.Mvc;
using OrderManagement.Interfaces.IServices;
using OrderManagement.Models.DTO;

namespace OrderManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        protected readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPublicAsync()
        {
            var product = await _service.GetAllPublicAsync();
            return Ok(product);
        }
        [HttpGet("admin")]
        public async Task<IActionResult> GetAllPublicAdminAsync()
        {
            var product = await _service.GetAllPublicAdminAsync();
            return Ok(product);
        }
        [HttpGet("admin/{id:int}")]
        public async Task<IActionResult> GetByIdAdminAsync(int id)
        {
            var product = await _service.GetByIdAdminAsync(id);
            return Ok(product);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdPublicAsync(int id)
        {
            var product = await _service.GetByIdPublicAsync(id);
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Product Deleted Succesfully!");
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductCreateDto productCreate)
        {
            await _service.CreateAsync(productCreate);
            return Ok("Product Created Successfully!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ProductUpdateDto productUpdate)
        {
            await _service.UpdateAsync(id, productUpdate);
            return Ok("Product       Updated Successfully!");
        }

    }
}
