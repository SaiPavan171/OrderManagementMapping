using Microsoft.AspNetCore.Mvc;
using OrderManagement.Interfaces.IServices;
using OrderManagement.Models.DTO;

namespace OrderManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        protected readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var orders = await _service.GetAllAsync();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var order = await _service.GetByIdAsync(id);
            return Ok(order);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Order Deleted Succesfully!");
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(OrderCreateDto order)
        {
            await _service.CreateAsync(order);
            return Ok("Category Created Successfully!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, OrderCreateDto order)
        {
            await _service.UpdateAsync(id, order);
            return Ok("Category Updated Successfully!");
        }
    }
}
