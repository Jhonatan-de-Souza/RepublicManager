using System;
using System.Collections.Generic;
using System.Linq;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Resources;

namespace RepublicManager.Api.Core.Resources
{
    public class CarrinhoDeCompraResource :Base
    {
        public int Id { get; set; }
        public int RepublicaId { get; set; }
        public IEnumerable<ProdutoResource> ListaProdutos { get; set; }

       
    }



    public static class CarrinhoDeCompraMapper
    {
        public static CarrinhoDeCompraResource ModelToResource(CarrinhoDeCompra carrinhoDeCompra)
        {
            var carrinhoDeCompraResource = new CarrinhoDeCompraResource()
            {
                RepublicaId = carrinhoDeCompra.RepublicaId,
                ListaProdutos = carrinhoDeCompra.Produtos.Select(produto => produto.ProdutoToProdutoResource()),

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
            carrinhoDeCompra.Produtos = carrinhoDeCompraResource.ListaProdutos.Select(produto => produto.ProdutoResourceToProduto());

            carrinhoDeCompra.Id = carrinhoDeCompraResource.Id;
            carrinhoDeCompra.IsAtivo = carrinhoDeCompraResource.IsAtivo;
            carrinhoDeCompra.CriadoPor = carrinhoDeCompraResource.CriadoPor;
            carrinhoDeCompra.DataRegistro = (carrinhoDeCompraResource.Id > 0) ? carrinhoDeCompra.DataRegistro : DateTime.Now;

            return carrinhoDeCompra;
        }

    }


}


public static class ProdutoExtensions
{
    public static Produto ProdutoResourceToProduto(this ProdutoResource produtoResoure)
    {
        return new Produto();
    }
    public static ProdutoResource ProdutoToProdutoResource(this Produto produto)
    {
      return  ProdutoMapper.ModelToResource(produto);
    }
}