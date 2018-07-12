using System;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class ProdutoResource
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int CarrinhoDeCompraId { get; set; }
        public CarrinhoDeCompraResource CarrinhoDeCompra { get; set; }
        public int UsuarioId { get; set; }

        public ProdutoResource()
        {
            isAtivo = true;
        }
        public DateTime DataRegistro { get; set; }
        public bool isAtivo { get; set; }
        public int CriadoPor { get; set; }
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
                isAtivo = produto.IsAtivo,
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
            produto.IsAtivo = produtoResource.isAtivo;
            produto.CriadoPor = produtoResource.CriadoPor;
            produto.DataRegistro = produtoResource.DataRegistro;

            return produto;
        }
    }
}
