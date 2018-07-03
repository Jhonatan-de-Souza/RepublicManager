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

        public DbSet<Republica> Republicas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new AvisosConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }
        public DbSet<RepublicManager.Api.Core.Domain.Aviso> Aviso { get; set; }
    }
}