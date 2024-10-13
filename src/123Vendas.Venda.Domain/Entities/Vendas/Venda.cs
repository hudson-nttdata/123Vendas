namespace Venda.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Venda
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
        public DateTime DataVenda { get; set; }
        // referencia entidade Cliente, usando padrao 'External Identities'
        public Guid ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        // referencia entidade Filial, usando padrao 'External Identities'
        public Guid FilialId { get; set; }
        public List<ItemVenda> Itens { get; set; }
        public bool Cancelado { get; set; }
    }

    public class ItemVenda
    {
        // referencia entidade Produto, usando padrao 'External Identities'
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal => (Quantidade * ValorUnitario) - Desconto;
    }
}
