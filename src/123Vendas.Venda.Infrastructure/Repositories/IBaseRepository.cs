namespace _123Vendas.Venda.Infrastructure.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int? id);
        void UpdateAsync(TEntity entity);
        Task SaveChangesAsync();
        Task DeleteAsync(TEntity entity);
    }
}
