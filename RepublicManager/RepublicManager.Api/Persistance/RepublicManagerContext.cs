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
    }
}