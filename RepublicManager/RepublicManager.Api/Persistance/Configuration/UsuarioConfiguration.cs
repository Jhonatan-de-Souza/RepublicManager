using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Persistance.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Login).IsRequired();
            builder.Property(u => u.Senha).IsRequired();
            builder.Property(x => x.DataFinalContrato).IsRequired();

            
            builder.HasOne(x => x.Conta)
                .WithOne(x => x.Usuario).HasForeignKey<Conta>(x => x.UsuarioId);
        }
    }
}

