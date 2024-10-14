using _123Vendas.Venda.Infrastructure.Repositories;
using Moq;

namespace _123Vendas.Venda.Tests.Mocks
{
    public class BaseRepositoryMock<TEntity> where TEntity : class
    {
        public Mock<IBaseRepository<TEntity>> Instance { get; }

        public BaseRepositoryMock()
        {
            Instance = new Mock<IBaseRepository<TEntity>>();

            Instance.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<TEntity>());
            Instance.Setup(repo => repo.AddAsync(It.IsAny<TEntity>())).Returns(Task.CompletedTask);
            Instance.Setup(repo => repo.UpdateAsync(It.IsAny<TEntity>()));
            Instance.Setup(repo => repo.SaveChangesAsync()).Returns(Task.CompletedTask);
        }
    }
}
