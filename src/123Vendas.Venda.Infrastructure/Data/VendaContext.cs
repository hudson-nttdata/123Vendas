using _123Vendas.Venda.Domain.Entities.Vendas;
using Microsoft.EntityFrameworkCore;

namespace _123Vendas.Venda.Infrastructure.Data
{
    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> options)
        : base(options) { }

        public DbSet<OrdemVenda> OrdemVendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdemVenda>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Numero).IsRequired();
                entity.Property(v => v.DataVenda).IsRequired();
                entity.Property(v => v.ValorTotal);

                entity.HasMany(v => v.Itens)
                      .WithOne()
                      .HasForeignKey("VendaId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ItemVenda>(entity =>
            {
                entity.HasKey(i => i.ProdutoId);
                entity.Property(i => i.ValorUnitario);
                entity.Property(i => i.Desconto);
            });

        }
    }
}
