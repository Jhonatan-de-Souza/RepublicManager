using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Configuration;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Persistance
{
    public class RepublicManagerContext : DbContext
    {
        public RepublicManagerContext(DbContextOptions<RepublicManagerContext> options)
            : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new AvisosConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new CarrinhoDeCompraConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }
        public DbSet<Aviso> Aviso { get; set; }
        public DbSet<Republica> Republica { get; set; }
        public DbSet<CarrinhoDeCompra> CarrinhoDeCompra { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}