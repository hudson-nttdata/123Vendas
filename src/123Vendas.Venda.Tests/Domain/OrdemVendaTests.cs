using _123Vendas.Venda.Domain.Entities.Vendas;

namespace _123Vendas.Venda.Tests.Domain
{
    public class OrdemVendaTests
    {
        [Fact]
        public void Criar_OrdemVenda_Successo()
        {
            // Arrange
            Guid id = new();
            var numero = "123456";
            var dataVenda = new DateTime();
            Guid clienteId = new();
            decimal valorTotal = 10;
            Guid filialId = new();

            Guid productId = new();
            var quantidade = 1;
            decimal valorUnitario = 10;
            decimal desconto = 3;
            var valoTotal = quantidade * valorUnitario - desconto;

            // Act
            var itens = new List<ItemVenda>
            {
                new() {
                    ProdutoId = productId,
                    Quantidade = quantidade,
                    ValorUnitario = valorUnitario,
                    Desconto = desconto
                }
            };

            var venda = new OrdemVenda
            {
                Id = id,
                Numero = numero,
                DataVenda = dataVenda,
                ClienteId = clienteId,
                ValorTotal = valorTotal,
                FilialId = filialId,
                Itens = itens
            };


            // Assert
            Assert.Equal(id, venda.Id);
            Assert.Equal(numero, venda.Numero);
            Assert.Equal(dataVenda, venda.DataVenda);
            Assert.Equal(clienteId, venda.ClienteId);
            Assert.False(venda.Cancelado);
        }
    }
}
