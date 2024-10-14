using _123Vendas.Venda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace _123Vendas.Venda.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly VendaContext context;

        public BaseRepository(VendaContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity != null)
            {
                await context.Set<TEntity>().AddAsync(entity);
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int? id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            return entity!;
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }


        public void UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }
    }
}
