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
            builder.Property(u => u.Login).IsRequired();
            builder.Property(u => u.Senha).IsRequired();
            builder.Property(x => x.DataFinalContrato).IsRequired();

            //builder.has
            builder.HasOne(x => x.Conta)
                .WithOne(x => x.Usuario).HasForeignKey<Usuario>(x =>x.ContaId);
        }
    }
}

