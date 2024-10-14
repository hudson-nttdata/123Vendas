using MediatR;

namespace _123Vendas.Venda.Application.Events
{ 
    public class CompraCriadaEvent : INotification
    {
        public Guid VendaId { get; }

        public CompraCriadaEvent(Guid vendaId)
        {
            VendaId = vendaId;
        }
    }
}
