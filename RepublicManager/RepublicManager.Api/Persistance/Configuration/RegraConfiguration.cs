using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Persistance.Configuration
{
    public class RegraConfiguration : IEntityTypeConfiguration<Regra>
    {
        public void Configure(EntityTypeBuilder<Regra> builder)
        {
            //Definindo Primary Key
            builder.HasKey(regra => regra.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.Descricao)
                .IsRequired()
                .HasMaxLength(250);
        }
       
    }
}
