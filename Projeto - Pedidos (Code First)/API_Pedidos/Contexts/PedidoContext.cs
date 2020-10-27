using API_Pedidos.Domains;
using Microsoft.EntityFrameworkCore;

namespace API_Pedidos.Contexts
{
    public class PedidoContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Loja;User ID=sa;Password=sa132;");
            base.OnConfiguring(optionsBuilder);


        }

    }
}
