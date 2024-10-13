using Microsoft.EntityFrameworkCore;
using Venda.Domain.Entities;

namespace Venda.Infrastructure.Data.Contexts
{
    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.HasMany(v => v.Itens).WithOne().HasForeignKey("VendaId");
            });
        }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
    }
}
