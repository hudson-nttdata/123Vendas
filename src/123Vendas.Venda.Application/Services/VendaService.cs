using _123Vendas.Venda.Application.Commands.Vendas.Criar;
using _123Vendas.Venda.Infrastructure.Data;
using _123Vendas.Venda.Domain.Entities.Vendas;
using MediatR;

namespace _123Vendas.Venda.Application.Services
{
    public class VendaService
    {
        private readonly IMediator _mediator;
        private readonly VendaContext _context;

        public VendaService(IMediator mediator, VendaContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<Guid> CriarVendaAsync(CriarVendaCommand command)
        {
            var venda = new OrdemVenda
            {
                Id = Guid.NewGuid(),
                Numero = command.Numero,
                DataVenda = command.DataVenda,
                ClienteId = command.ClienteId,
                FilialId = command.FilialId,
                ValorTotal = command.ValorTotal,
                Itens = command.Itens.Select(i => new ItemVenda
                {
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade,
                    ValorUnitario = i.ValorUnitario,
                    Desconto = i.Desconto
                }).ToList()
            };

            await _context.Vendas.AddAsync(venda);
            await _context.SaveChangesAsync();

            // Publicar o evento
            //var evento = new CompraCriadaEvent(venda.Id);
            //await _mediator.Publish(evento);

            return venda.Id;
        }
    }
}