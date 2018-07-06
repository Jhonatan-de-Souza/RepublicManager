using RepublicManager.Api.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicManager.Api.Resources
{
    public class CarrinhoDeCompraResource
    {
        public int Id { get; set; }
        public int RepublicaId { get; set; }
        public List<Produto> ListaProdutos { get; set; }

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
                ListaProdutos = carrinhoDeCompra.ListaProdutos,

                Id = carrinhoDeCompra.Id,
                isAtivo = carrinhoDeCompra.isAtivo,
                CriadoPor = carrinhoDeCompra.CriadoPor,
                DataRegistro = carrinhoDeCompra.DataRegistro
            };
            return carrinhoDeCompraResource;
        }
        public static CarrinhoDeCompra ResourceToModel(CarrinhoDeCompraResource carrinhoDeCompraResource,CarrinhoDeCompra carrinhoDeCompra)
        {

            carrinhoDeCompra.RepublicaId = carrinhoDeCompraResource.RepublicaId;
            carrinhoDeCompra.ListaProdutos = carrinhoDeCompraResource.ListaProdutos;

            carrinhoDeCompra.Id = carrinhoDeCompraResource.Id;
            carrinhoDeCompra.isAtivo = carrinhoDeCompraResource.isAtivo;
            carrinhoDeCompra.CriadoPor = carrinhoDeCompraResource.CriadoPor;
            carrinhoDeCompra.DataRegistro = carrinhoDeCompraResource.DataRegistro;
            
            return carrinhoDeCompra;
        }
    }
}
