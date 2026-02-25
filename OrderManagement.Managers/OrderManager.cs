using AutoMapper;
using OrderManagement.DataAccess.Entites;
using OrderManagement.Interfaces.IManagers;
using OrderManagement.Interfaces.IRepositries;
using OrderManagement.Models.DTO;

namespace OrderManagement.Managers
{
    public class OrderManager:IOrderManager
    {
        protected readonly IGenericRepository<Order> _repository;
        protected readonly IMapper _mapper;
        public OrderManager(IGenericRepository<Order> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            return _mapper.Map<OrderDto>(order);
        }
        public async Task DeleteAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(order);
        }
        public async Task CreateAsync(OrderCreateDto createOrder)
        {
            var order=_mapper.Map<Order>(createOrder);
            await _repository.CreateAsync(order);
        }
        public async Task UpdateAsync(int id,OrderCreateDto orderUpdate)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order != null)
            {
                _mapper.Map(orderUpdate, order);
                await _repository.UpdateAsync(order);

            }
        }
    }
}
