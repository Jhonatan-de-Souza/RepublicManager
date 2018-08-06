using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepublicManager.Api.Core.Domain
{
    public class ContaAPagar : Base
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int TipoContaId { get; set; }
        public virtual TipoConta TipoConta { get; set; }
        public int ContaId { get; set; }
        public virtual Conta Conta { get; set; }
    }
}
