using OrderManagement.DataAccess.Entites;
using OrderManagement.Interfaces.IManagers;
using OrderManagement.Interfaces.IServices;
using OrderManagement.Models.DTO;

namespace OrderManagement.Services
{
    public class OrderService:IOrderService
    {
        protected readonly IOrderManager _manager;
        public OrderService(IOrderManager manager)
        {
            _manager = manager; 
        }
        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            return await _manager.GetAllAsync();
            
        }
        public async Task<OrderDto> GetByIdAsync(int id)
        {
            return await _manager.GetByIdAsync(id);
        }
        public async Task DeleteAsync(int id)
        {
           await _manager.DeleteAsync(id);
        }
        public async Task CreateAsync(OrderCreateDto createOrder)
        {
            await _manager.CreateAsync(createOrder);
        }
        public async Task UpdateAsync(int id, OrderCreateDto orderUpdate)
        {
            await _manager.UpdateAsync(id, orderUpdate);   
        }
    }
}
