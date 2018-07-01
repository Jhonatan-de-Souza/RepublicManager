using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Configuration
{
    public class CarrinhoDeCompraConfiguration : IEntityTypeConfiguration<CarrinhoDeCompra>
    {
        public void Configure(EntityTypeBuilder<CarrinhoDeCompra> builder)
        {
            

            //1-1

            builder.HasOne(p => p.ListaProdutos).WithOne(nameof(Produto));

        }
    }
}
