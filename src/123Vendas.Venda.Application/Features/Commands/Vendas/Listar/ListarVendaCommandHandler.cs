using _123Vendas.Venda.Domain.Entities.Vendas;
using _123Vendas.Venda.Infrastructure.Repositories;
using MediatR;
using Serilog;

namespace _123Vendas.Venda.Application.Features.Commands.Vendas.Listar
{
    public class ListarVendaCommandHandler : IRequestHandler<ListarVendaCommand, List<OrdemVenda>>
    {       
        private readonly IBaseRepository<OrdemVenda> _vendaRepository;

        public ListarVendaCommandHandler(IBaseRepository<OrdemVenda> vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<List<OrdemVenda>> Handle(ListarVendaCommand request, CancellationToken cancellationToken)
        {
            Log.Information("Obtenção de itens da tabela de vendas.");
            IEnumerable<OrdemVenda> vendas = await _vendaRepository.GetAllAsync();

            Log.Information("Itens obtidos com êxito.");
            return vendas.ToList();
        }
    }
}
