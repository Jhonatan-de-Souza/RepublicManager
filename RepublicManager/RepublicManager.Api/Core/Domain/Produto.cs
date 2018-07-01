using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicManager.Api.Core.Domain
{
    public class Produto : Base
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int CarrinhoDeCompraId { get; set; }
        public int UsuarioId { get; set; }
    }
}
