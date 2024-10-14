using _123Vendas.Venda.Application.Services;
using Moq;

namespace _123Vendas.Venda.Tests.Mocks
{
    internal class VendaServiceMock
    {
        public Mock<VendaService> Instance { get; }
        
        public VendaServiceMock()
        {
            Instance = new Mock<VendaService>();
        }
    }
}
