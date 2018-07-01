using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicManager.Api.Core.Domain
{
    public class CarrinhoDeCompra : Base
    {
        public int Id { get; set; }
        public int RepublicaId { get; set; }
        public List<Produto> ListaProdutos { get; set; }
    }
}
