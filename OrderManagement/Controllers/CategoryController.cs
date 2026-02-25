using Microsoft.AspNetCore.Mvc;
using OrderManagement.DataAccess.Entites;
using OrderManagement.Interfaces.IServices;
using OrderManagement.Models.DTO;

namespace OrderManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        protected readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var category = await  _service.GetAllAsync();
            return Ok(category);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var category = await _service.GetByIdAsync(id);
            return Ok(category);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Category Deleted Succesfully!");
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryCreate category)
        {
            await _service.CreateAsync(category);
            return Ok("Category Created Successfully!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id , CategoryCreate category)
        {
            await _service.UpdateAsync(id, category);
            return Ok("Category Updated Successfully!");
        }

    }
}
