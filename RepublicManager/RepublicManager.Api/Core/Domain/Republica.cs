using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepublicManager.Api.Core.Domain
{
    public class Republica : Base
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Vagas { get; set; }
        public virtual IEnumerable<Regra> Regras { get; set; }
        public virtual IEnumerable<Aviso> Avisos { get; set; }
        public virtual IEnumerable<Usuario> Usuarios { get; set; }
        public virtual IEnumerable<CarrinhoDeCompra> CarrinhosDeCompra { get; set; }

    }
}
