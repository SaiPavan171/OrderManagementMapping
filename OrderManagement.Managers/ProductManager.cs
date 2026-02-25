using AutoMapper;
using OrderManagement.DataAccess.Entites;
using OrderManagement.Interfaces.IManagers;
using OrderManagement.Interfaces.IRepositries;
using OrderManagement.Models.DTO;

namespace OrderManagement.Managers
{
    public class ProductManager:IProductManager
    {
        protected readonly IGenericRepository<Product> _repository;
        protected readonly IMapper _mapper;
        public ProductManager(IGenericRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductPublicDto>> GetAllPublicAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductPublicDto>>(products);
        }
        public async Task<IEnumerable<ProductAdminDto>> GetAllPublicAdminAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductAdminDto>>(products);
        }
        public async Task<ProductAdminDto> GetByIdAdminAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductAdminDto>(product);
        }
        public async Task<ProductPublicDto> GetByIdPublicAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductPublicDto>(product);
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(product);
        }
        public async Task CreateAsync(ProductCreateDto productCreate)
        {
            var product=_mapper.Map<Product>(productCreate);
            await _repository.CreateAsync(product);
        }
        public async Task UpdateAsync(int id , ProductUpdateDto productUpdate)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product != null)
            {
                _mapper.Map(productUpdate, product);
                await _repository.UpdateAsync(product);
            }
            
        }


    }
}
