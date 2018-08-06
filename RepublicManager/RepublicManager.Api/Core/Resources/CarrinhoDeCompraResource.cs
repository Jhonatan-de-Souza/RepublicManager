using System;
using System.Collections.Generic;
using System.Linq;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Resources;

namespace RepublicManager.Api.Core.Resources
{
    public class CarrinhoDeCompraResource : Base
    {
        public int Id { get; set; }
        public int RepublicaId { get; set; }
        public IEnumerable<ProdutoResource> Produtos { get; set; }


    }



    public static class CarrinhoDeCompraMapper
    {
        public static CarrinhoDeCompraResource ModelToResource(CarrinhoDeCompra carrinhoDeCompra)
        {
            var carrinhoDeCompraResource = new CarrinhoDeCompraResource()
            {
                RepublicaId = carrinhoDeCompra.RepublicaId,
                Produtos = carrinhoDeCompra.Produtos.Select(ProdutoMapper.ModelToResource),

                Id = carrinhoDeCompra.Id,
                IsAtivo = carrinhoDeCompra.IsAtivo,
                CriadoPor = carrinhoDeCompra.CriadoPor,
                DataRegistro = carrinhoDeCompra.DataRegistro
            };
            return carrinhoDeCompraResource;
        }
        public static CarrinhoDeCompra ResourceToModel(CarrinhoDeCompraResource carrinhoDeCompraResource, CarrinhoDeCompra carrinhoDeCompra)
        {

            carrinhoDeCompra.RepublicaId = carrinhoDeCompraResource.RepublicaId;
            carrinhoDeCompra.Id = (carrinhoDeCompra.Id > 0) ? carrinhoDeCompra.Id : carrinhoDeCompraResource.Id;
            carrinhoDeCompra.IsAtivo = carrinhoDeCompraResource.IsAtivo;
            carrinhoDeCompra.CriadoPor = carrinhoDeCompraResource.CriadoPor;
            carrinhoDeCompra.DataRegistro = (carrinhoDeCompraResource.Id > 0) ? carrinhoDeCompra.DataRegistro : DateTime.Now;

            return carrinhoDeCompra;
        }

    }


}

