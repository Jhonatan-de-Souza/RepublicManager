using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Configuration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(p => p.Valor).HasColumnType("decimal(18, 2)");

            //1-1

           // builder.HasOne(p => p.CarrinhoDeCompra).WithOne(nameof(CarrinhoDeCompra));
        }

    }
}
