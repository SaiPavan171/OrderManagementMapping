using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess.Context;
using OrderManagement.Interfaces.IRepositries;

namespace OrderManagement.DataAccess.Repositries
{
    public class BaseRepositry<T>: IGenericRepository<T> where T :class
    {
        protected readonly AppDbContext _context;
        public BaseRepositry(AppDbContext context) { _context = context; }
        

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return  await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task CreateAsync(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
            _context.SaveChanges();
        }
        public async Task DeleteAsync(T Entity)
        {
            _context.Set<T>().Remove(Entity);
            _context.SaveChanges();
        }
        public async Task UpdateAsync(T Entity)
        {
            _context.Set<T>().Update(Entity);
            _context.SaveChanges();
        }
    }
}
