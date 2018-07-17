using System;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class ProdutoResource : Base
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int CarrinhoDeCompraId { get; set; }
        public CarrinhoDeCompraResource CarrinhoDeCompra { get; set; }
        public int UsuarioId { get; set; }


    }



    public static class ProdutoMapper
    {
        public static ProdutoResource ModelToResource(Produto produto)
        {
            var produtoResource = new ProdutoResource()
            {
                Descricao = produto.Descricao,
                Valor = produto.Valor,
                CarrinhoDeCompraId = produto.CarrinhoDeCompraId,
                UsuarioId = produto.UsuarioId,

                Id = produto.Id,
                IsAtivo = produto.IsAtivo,
                CriadoPor = produto.CriadoPor,
                DataRegistro = produto.DataRegistro
            };
            return produtoResource;
        }
        public static Produto ResourceToModel(ProdutoResource produtoResource, Produto produto)
        {

            produto.Descricao = produtoResource.Descricao;
            produto.Valor = produtoResource.Valor;
            produto.CarrinhoDeCompraId = produtoResource.CarrinhoDeCompraId;
            produto.UsuarioId = produtoResource.UsuarioId;

            produto.Id = produtoResource.Id;    
            produto.IsAtivo = produtoResource.IsAtivo;
            produto.CriadoPor = produtoResource.CriadoPor;
            produto.DataRegistro = (produtoResource.Id > 0) ? produto.DataRegistro : DateTime.Now;

            return produto;
        }
    }
}
