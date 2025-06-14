using Microsoft.EntityFrameworkCore;
using WebApiVendas.Entidades;

namespace WebApiVendas.Data.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }

    }
}
