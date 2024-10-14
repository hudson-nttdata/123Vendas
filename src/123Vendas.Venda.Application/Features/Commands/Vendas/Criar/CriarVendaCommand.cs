using MediatR;

namespace _123Vendas.Venda.Application.Features.Commands.Vendas.Criar
{
    public class CriarVendaCommand : IRequest<Guid>
    {
        public string NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public Guid ClienteId { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public Guid FilialId { get; set; }
        public required List<ItemVendaDto> Itens { get; set; }
    }

    public class ItemVendaDto
    {
        public Guid ItemId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Desconto { get; set; }
    }

}