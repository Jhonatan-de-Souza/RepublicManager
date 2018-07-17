using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepublicManager.Api.Core.Domain
{
    public class Conta : Base
    {

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public IEnumerable<ContaAPagar> ContasAPagar { get; set; }
        public IEnumerable<ContaAReceber> ContasAReceber { get; set; }
    }
}
