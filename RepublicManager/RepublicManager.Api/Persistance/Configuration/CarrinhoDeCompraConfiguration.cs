﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Persistance.Configuration
{
    public class CarrinhoDeCompraConfiguration : IEntityTypeConfiguration<CarrinhoDeCompra>
    {
        public void Configure(EntityTypeBuilder<CarrinhoDeCompra> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.Produtos)
                .WithOne(c => c.CarrinhoDeCompra).HasForeignKey(x => x.CarrinhoDeCompraId)
                .IsRequired();


        }
    }
}
