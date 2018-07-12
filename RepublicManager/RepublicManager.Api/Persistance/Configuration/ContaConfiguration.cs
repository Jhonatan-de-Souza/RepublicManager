using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Persistance.Configuration
{
    public class ContaConfiguration : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(x => x.ContasAPagar)
                .WithOne(c => c.Conta)
                .IsRequired();

            builder.HasMany(x => x.ContasAReceber)
                .WithOne(c => c.Conta)
                .IsRequired();
        }
    }
}
