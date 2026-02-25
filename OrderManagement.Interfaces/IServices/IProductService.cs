using OrderManagement.Models.DTO;

namespace OrderManagement.Interfaces.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductPublicDto>> GetAllPublicAsync();
        Task<IEnumerable<ProductAdminDto>> GetAllPublicAdminAsync();
        Task<ProductPublicDto> GetByIdPublicAsync(int id);
        Task<ProductAdminDto> GetByIdAdminAsync(int id);
        Task DeleteAsync(int id);
        Task CreateAsync(ProductCreateDto product);
        Task UpdateAsync(int id, ProductUpdateDto product);
    }
}
