using _123Vendas.Venda.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace _123Vendas.Venda.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly VendaDbContext _context;

        public BaseRepository(VendaDbContext context)
        {
            this._context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity != null)
            {
                await _context.Set<TEntity>().AddAsync(entity);
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int? id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            return entity!;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        public void UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
