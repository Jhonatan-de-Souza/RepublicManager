﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Persistance.Configuration 
{
    public class RepublicaConfiguration : IEntityTypeConfiguration<Republica>
    {
        public void Configure(EntityTypeBuilder<Republica> builder)
        {
            builder.ToTable("Republica");
            //Definindo Primary Key
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Nome).IsRequired().HasMaxLength(100);
            builder.Property(r => r.Vagas).IsRequired();
            builder.HasMany(x => x.Regras)
                .WithOne(x => x.Republica)
                .IsRequired();
        }
    }
}
