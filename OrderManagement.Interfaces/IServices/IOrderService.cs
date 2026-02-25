using OrderManagement.Models.DTO;

namespace OrderManagement.Interfaces.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<OrderDto> GetByIdAsync(int id);
        Task CreateAsync(OrderCreateDto order);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, OrderCreateDto order);
    }
}
