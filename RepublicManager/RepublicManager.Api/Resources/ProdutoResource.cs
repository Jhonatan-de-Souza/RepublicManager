using RepublicManager.Api.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicManager.Api.Resources
{
    public class ProdutoResource
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int CarrinhoDeCompraId { get; set; }
        public CarrinhoDeCompra CarrinhoDeCompra { get; set; }
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
                CarrinhoDeCompra = produto.CarrinhoDeCompra,
                UsuarioId = produto.UsuarioId,
                Id = produto.Id,
                isAtivo = produto.isAtivo,
                CriadoPor = produto.CriadoPor,
                DataRegistro = produto.DataRegistro
            };
            return produtoResource;
        }
        public static Produto ResourceToModel(ProdutoResource produtoResource)
        {
            var produto = new Produto()
            {
                Descricao = produtoResource.Descricao,
                Valor = produtoResource.Valor,
                CarrinhoDeCompraId = produtoResource.CarrinhoDeCompraId,
                CarrinhoDeCompra = produtoResource.CarrinhoDeCompra,
                UsuarioId = produtoResource.UsuarioId,
                Id = produtoResource.Id,
                isAtivo = produtoResource.isAtivo,
                CriadoPor = produtoResource.CriadoPor,
                DataRegistro = produtoResource.DataRegistro
            };
            return produto;
        }
    }
}
