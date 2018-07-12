using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Persistance.Configuration
{
    public class TipoContaConfiguration : IEntityTypeConfiguration<TipoConta>
    {
        public void Configure(EntityTypeBuilder<TipoConta> builder)
        {
            builder.HasKey(tipoConta => tipoConta.Id);
            builder.Property(x => x.Descricao).HasMaxLength(250);
        }
    }
}
