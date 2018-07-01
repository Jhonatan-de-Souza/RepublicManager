using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Persistance
{
    public class RepublicManagerContext : DbContext
    {
        public RepublicManagerContext(DbContextOptions<RepublicManagerContext> options)
            : base(options)
        { }

        public DbSet<Republica> Republicas { get; set; }
    }
}