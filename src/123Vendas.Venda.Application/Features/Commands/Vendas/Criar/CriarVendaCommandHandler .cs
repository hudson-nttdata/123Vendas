using _123Vendas.Venda.Application.Events;
using _123Vendas.Venda.Domain.Entities.Vendas;
using _123Vendas.Venda.Infrastructure.Data.Contexts;
using MediatR;

namespace _123Vendas.Venda.Application.Features.Commands.Vendas.Criar
{
    public class CriarVendaCommandHandler : IRequestHandler<CriarVendaCommand, Guid>
    {
        private readonly VendaDbContext _context;
        private readonly IMediator _mediator;

        public CriarVendaCommandHandler(VendaDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CriarVendaCommand request, CancellationToken cancellationToken)
        {
            var venda = new OrdemVenda
            {
                Id = Guid.NewGuid(),
                NumeroVenda = request.NumeroVenda,
                DataVenda = request.DataVenda,
                ClienteId = request.ClienteId,
                FilialId = request.FilialId,
                ValorTotalVenda = request.ValorTotalVenda,
                Itens = request.Itens.Select(i => new VendaItem
                {
                    ItemId = i.ItemId,
                    Quantidade = i.Quantidade,
                    ValorUnitario = i.ValorUnitario,
                    Desconto = i.Desconto
                }).ToList(),
                VendaCancelada = false
            };

            await _context.OrdemVendas.AddAsync(venda);
            await _context.SaveChangesAsync(cancellationToken);

            // Publicar evento de Venda Criada
            var evento = new CompraCriadaEvent(venda.Id);
            await _mediator.Publish(evento, cancellationToken);

            return venda.Id;
        }
    }
}
