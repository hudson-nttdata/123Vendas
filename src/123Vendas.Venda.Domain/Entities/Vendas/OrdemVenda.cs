namespace _123Vendas.Venda.Domain.Entities.Vendas
{
    public class OrdemVenda
    {
        public Guid Id { get; set; }
        public string NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public Guid ClienteId { get; set; }
        public decimal ValorTotalVenda { get; set; }
        public Guid FilialId { get; set; }
        public List<VendaItem> Itens { get; set; }
        public bool VendaCancelada { get; set; }

        public OrdemVenda()
        {
            Itens = new List<VendaItem>();
        }
    }

    public class VendaItem
    {
        public Guid ItemId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal Valor => Quantidade * ValorUnitario - Desconto;
    }
}
