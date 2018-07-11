using System;
using System.Collections.Generic;
using System.Linq;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Resources;

namespace RepublicManager.Api.Core.Resources
{
    public class CarrinhoDeCompraResource
    {
        public int Id { get; set; }
        public int RepublicaId { get; set; }
        public IEnumerable<ProdutoResource> ListaProdutos { get; set; }

        public CarrinhoDeCompraResource()
        {
            isAtivo = true;
        }
        public DateTime DataRegistro { get; set; }
        public bool isAtivo { get; set; }
        public int CriadoPor { get; set; }
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
                isAtivo = carrinhoDeCompra.IsAtivo,
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
            carrinhoDeCompra.IsAtivo = carrinhoDeCompraResource.isAtivo;
            carrinhoDeCompra.CriadoPor = carrinhoDeCompraResource.CriadoPor;
            carrinhoDeCompra.DataRegistro = carrinhoDeCompraResource.DataRegistro;

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