using _123Vendas.Venda.Domain.Entities.Vendas;
using _123Vendas.Venda.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace _123Vendas.Venda.Tests.Infrastructure
{
    public class VendaContextTests
    {

        [Fact]
        public async Task Persistir_Venda_Sucesso()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<VendaDbContext>()
                .UseInMemoryDatabase(databaseName: "Persistir_Venda_Sucesso")
                .Options;

            using (var dbContext = new VendaDbContext(options))
            {
                // Act
                dbContext.OrdemVendas.Add(new OrdemVenda
                {
                    // TODO: preencher objeto
                });
                dbContext.VendaItems.Add(new VendaItem
                {
                    // TODO: preencher objeto
                });
                dbContext.SaveChanges();
            }

            using (var dbContext = new VendaDbContext(options))
            {
                // Assert
                var venda = await dbContext.OrdemVendas.FirstOrDefaultAsync(c => c.Id == new Guid());
                var itemVenda = await dbContext.VendaItems.FirstOrDefaultAsync(c => c.ItemId == new Guid());
                Assert.NotNull(venda);
                Assert.NotNull(itemVenda);
            }
        }
    }
}
