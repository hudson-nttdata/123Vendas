using _123Vendas.Venda.Domain.Entities.Vendas;
using _123Vendas.Venda.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace _123Vendas.Venda.Tests.Infrastructure
{
    public class VendaContextTests
    {

        [Fact]
        public async Task Persistir_Venda_Sucesso()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<VendaContext>()
                .UseInMemoryDatabase(databaseName: "Persistir_Venda_Sucesso")
                .Options;

            using (var dbContext = new VendaContext(options))
            {
                // Act
                dbContext.OrdemVendas.Add(new OrdemVenda
                {
                    // TODO: preencher objeto
                });
                dbContext.ItensVenda.Add(new ItemVenda
                {
                    // TODO: preencher objeto
                });
                dbContext.SaveChanges();
            }

            using (var dbContext = new VendaContext(options))
            {
                // Assert
                var venda = await dbContext.OrdemVendas.FirstOrDefaultAsync(c => c.Id == new Guid());
                var itemVenda = await dbContext.ItensVenda.FirstOrDefaultAsync(c => c.ProdutoId == new Guid());
                Assert.NotNull(venda);
                Assert.NotNull(itemVenda);
            }
        }
    }
}
