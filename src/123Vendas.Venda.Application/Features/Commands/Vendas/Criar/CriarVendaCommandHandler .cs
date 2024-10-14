using _123Vendas.Venda.Domain.Entities.Vendas;
using _123Vendas.Venda.Infrastructure.Data;
using MediatR;

namespace _123Vendas.Venda.Application.Features.Commands.Vendas.Criar
{
    public class CriarVendaCommandHandler : IRequestHandler<CriarVendaCommand, Guid>
    {
        private readonly VendaContext _context;
        private readonly IMediator _mediator;

        public CriarVendaCommandHandler(VendaContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CriarVendaCommand request, CancellationToken cancellationToken)
        {
            var venda = new OrdemVenda
            {
                Id = Guid.NewGuid(),
                Numero = request.Numero,
                DataVenda = request.DataVenda,
                ClienteId = request.ClienteId,
                FilialId = request.FilialId,
                ValorTotal = request.ValorTotal,
                Itens = request.Itens.Select(i => new ItemVenda
                {
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade,
                    ValorUnitario = i.ValorUnitario,
                    Desconto = i.Desconto
                }).ToList(),
                Cancelado = false
            };

            await _context.OrdemVendas.AddAsync(venda);
            await _context.SaveChangesAsync(cancellationToken);

            // Publicar evento de Venda Criada
            // var evento = new CompraCriadaEvent(venda.Id);
            // await _mediator.Publish(evento, cancellationToken);

            return venda.Id;
        }
    }
}
