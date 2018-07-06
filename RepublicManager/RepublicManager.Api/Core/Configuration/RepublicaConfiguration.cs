using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Configuration 
{
    public class RepublicaConfiguration : IEntityTypeConfiguration<Republica>
    {
        public void Configure(EntityTypeBuilder<Republica> builder)
        {
            builder.ToTable("Republica");
            //Definindo Primary Key
            builder.HasKey(r => r.Id);
        }
    }
}
