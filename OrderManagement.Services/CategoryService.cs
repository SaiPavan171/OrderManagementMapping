using OrderManagement.DataAccess.Entites;
using OrderManagement.Interfaces.IManagers;
using OrderManagement.Interfaces.IServices;
using OrderManagement.Models.DTO;

namespace OrderManagement.Services
{
    public class CategoryService:ICategoryService
    {
        protected readonly ICategoryManager _manager;
        public CategoryService(ICategoryManager manager)
        {
            _manager = manager;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return await _manager.GetAllAsync();
        }
        public async Task<CategoryDto> GetByIdAsync(int id)
        {
           return await _manager.GetByIdAsync(id);
        }
        public async Task DeleteAsync(int id)
        {
            await _manager.DeleteAsync(id);
        }
        public async Task CreateAsync(CategoryCreate categoryCreate)
        {
            await _manager.CreateAsync(categoryCreate);
        }
        public async Task UpdateAsync(int id, CategoryCreate categoryUpdate)
        {
            await _manager.UpdateAsync(id, categoryUpdate);
           
        }
    }
}
