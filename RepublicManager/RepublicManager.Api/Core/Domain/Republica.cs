using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepublicManager.Api.Core.Domain
{
    public class Republica : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Vagas { get; set; }
        public virtual IEnumerable<Regra> Regras { get; set; }

    }
}
