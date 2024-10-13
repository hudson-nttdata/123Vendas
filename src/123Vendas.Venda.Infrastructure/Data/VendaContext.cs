using _123Vendas.Venda.Domain.Entities.Vendas;
using Microsoft.EntityFrameworkCore;

namespace _123Vendas.Venda.Infrastructure.Data
{
    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdemVenda>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.HasMany(v => v.Itens).WithOne().HasForeignKey("VendaId");
            });
        }

        public DbSet<OrdemVenda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
    }
}
