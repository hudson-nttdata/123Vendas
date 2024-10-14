using MediatR;

namespace _123Vendas.Venda.Application.Features.Commands.Vendas.Criar
{
    public class CriarVendaCommand : IRequest<Guid>
    {
        public required string Numero { get; set; }
        public DateTime DataVenda { get; set; }
        public Guid ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public Guid FilialId { get; set; }
        public required List<ItemVendaDto> Itens { get; set; }
    }

    public class ItemVendaDto
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Desconto { get; set; }
    }
}