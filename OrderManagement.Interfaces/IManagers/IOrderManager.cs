using OrderManagement.Models.DTO;

namespace OrderManagement.Interfaces.IManagers
{
    public interface IOrderManager
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<OrderDto> GetByIdAsync(int id);
        Task CreateAsync(OrderCreateDto order);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, OrderCreateDto order);
    }
}
