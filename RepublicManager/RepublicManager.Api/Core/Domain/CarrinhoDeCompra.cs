using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepublicManager.Api.Core.Domain
{
    public class CarrinhoDeCompra : Base
    {
        public int Id { get; set; }
        public int RepublicaId { get; set; }
        public virtual Republica Republica { get; set; }
        public virtual  IEnumerable<Produto> Produtos { get; set; }

    }
}
