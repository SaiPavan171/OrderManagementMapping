using OrderManagement.Interfaces.IManagers;
using OrderManagement.Interfaces.IServices;
using OrderManagement.Models.DTO;

namespace OrderManagement.Services
{
    public class ProductService : IProductService
    {
        protected readonly IProductManager _manager;
        public ProductService(IProductManager manager)
        {
            _manager = manager;
        }
        public async Task<IEnumerable<ProductPublicDto>> GetAllPublicAsync()
        {
            return await _manager.GetAllPublicAsync();
        }
        public async Task<IEnumerable<ProductAdminDto>> GetAllPublicAdminAsync()
        {
            return await _manager.GetAllPublicAdminAsync();
        }
        public async Task<ProductAdminDto> GetByIdAdminAsync(int id)
        {
            return await _manager.GetByIdAdminAsync(id);
        }
        public async Task<ProductPublicDto> GetByIdPublicAsync(int id)
        {
            return await _manager.GetByIdPublicAsync(id);
        }
        public async Task DeleteAsync(int id)
        {
            await _manager.DeleteAsync(id);
        }
        public async Task CreateAsync(ProductCreateDto productCreate)
        {
            await _manager.CreateAsync(productCreate);
        }
        public async Task UpdateAsync(int id, ProductUpdateDto productUpdate)
        {
            await _manager.UpdateAsync(id, productUpdate);
        }
    }
}
