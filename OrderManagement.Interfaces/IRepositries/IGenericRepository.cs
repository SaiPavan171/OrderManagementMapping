using OrderManagement.Models.DTO;

namespace OrderManagement.Interfaces.IRepositries
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);
        //Task CreateAsync(T Entity);
        //Task CreateAsync(CategoryDto categoryCreate);
        //Task CreateAsync(OrderCreateDto createOrder);
        //Task CreateAsync(ProductCreateDto productCreate);
    }
}
