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
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.ContasAPagar)
                .WithOne(c => c.Conta)
                .HasForeignKey(x => x.ContaId)
                .IsRequired();

            builder.HasMany(x => x.ContasAReceber)
                .WithOne(c => c.Conta)
                .HasForeignKey(x => x.ContaId)
                .IsRequired();

            builder.HasOne(c => c.Usuario)
                .WithOne(c => c.Conta)
                .HasForeignKey<Usuario>(x => x.ContaId)
                .IsRequired();



        }
    }
}
