using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Persistance.Configuration
{
    public class AvisosConfiguration : IEntityTypeConfiguration<Aviso>
    {
        public void Configure(EntityTypeBuilder<Aviso> builder)
        {
            builder.ToTable("Aviso");
            //Definindo Primary Key
            builder.HasKey(aviso => aviso.Id);
            builder.Property(aviso => aviso.Descricao)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(aviso => aviso.DataAviso)
                .IsRequired();
            
            
        }
    }
}

