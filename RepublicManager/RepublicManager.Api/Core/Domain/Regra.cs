using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepublicManager.Api.Core.Domain
{
    public class Regra : Base
    {
        public int Id { get; set; }
        public int RepublicaId { get; set; }
        public string Descricao { get; set; }
        public virtual Republica Republica { get; set; }


    }
}
