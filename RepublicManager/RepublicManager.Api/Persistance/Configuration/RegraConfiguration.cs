using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicManager.Api.Persistance.Configuration
{
    public class RegraConfiguration : IEntityTypeConfiguration<Regra>
    {
        public void Configure(EntityTypeBuilder<Regra> builder)
        {
            //Definindo Primary Key
            builder.HasKey(regra => regra.Id);
            builder.Property(r => r.Descricao)
                .IsRequired()
                .HasMaxLength(250);
        }
       
    }
}
