using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepublicManager.Api.Core.Domain
{
    public class ContaAReceber : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int TipoContaId { get; set; }
        public TipoConta TipoConta { get; set; }
        public int ContaId { get; set; }
        public virtual Conta Conta { get; set; }
    }
}
