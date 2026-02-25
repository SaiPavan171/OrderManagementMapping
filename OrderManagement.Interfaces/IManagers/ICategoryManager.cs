using OrderManagement.Models.DTO;

namespace OrderManagement.Interfaces.IManagers
{
    public interface ICategoryManager
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CategoryCreate category);
        Task UpdateAsync(int id , CategoryCreate category);
        Task DeleteAsync(int id);
    }
}
