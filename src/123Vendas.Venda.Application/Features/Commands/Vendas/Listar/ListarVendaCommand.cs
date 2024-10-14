using _123Vendas.Venda.Domain.Entities.Vendas;
using MediatR;

namespace _123Vendas.Venda.Application.Features.Commands.Vendas.Listar
{
    public class ListarVendaCommand : IRequest<List<OrdemVenda>>
    {
    }
}
