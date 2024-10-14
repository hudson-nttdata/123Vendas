using _123Vendas.Venda.Domain.Entities.Vendas;
using Microsoft.EntityFrameworkCore;

namespace _123Vendas.Venda.Infrastructure.Data.Contexts
{
    public class VendaDbContext : DbContext
    {
        public VendaDbContext(DbContextOptions<VendaDbContext> options)
        : base(options) { }

        public DbSet<OrdemVenda> OrdemVendas { get; set; }
        public DbSet<VendaItem> VendaItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdemVenda>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.NumeroVenda).IsRequired();
                entity.Property(v => v.DataVenda).IsRequired();
                entity.Property(v => v.ValorTotalVenda);

                entity.HasMany(v => v.Itens)
                      .WithOne()
                      .HasForeignKey("VendaId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<VendaItem>(entity =>
            {
                entity.HasKey(i => i.ItemId);
                entity.Property(i => i.ValorUnitario);
                entity.Property(i => i.Desconto);
            });

        }
    }
}
