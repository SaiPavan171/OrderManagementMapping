using AutoMapper;
using OrderManagement.DataAccess.Entites;
using OrderManagement.Interfaces.IManagers;
using OrderManagement.Interfaces.IRepositries;
using OrderManagement.Models.DTO;

namespace OrderManagement.Managers
{
    public class CategoryManager:ICategoryManager
    {
        protected readonly IGenericRepository<Category> _repository;
        protected readonly IMapper _mapper;
        public CategoryManager(IGenericRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var category = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(category);
        }
        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }
        public async Task DeleteAsync(int id)
        {
            var cat = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(cat);
        }
        public async Task CreateAsync(CategoryCreate categoryCreate)
        {
            var cateogory = _mapper.Map<Category>(categoryCreate);
            await _repository.CreateAsync(cateogory);
        }
        public async Task UpdateAsync(int id, CategoryCreate categoryUpdate)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category != null)
            {
                _mapper.Map(categoryUpdate, category);
                await _repository.UpdateAsync(category);
            }
        }

    }
}
