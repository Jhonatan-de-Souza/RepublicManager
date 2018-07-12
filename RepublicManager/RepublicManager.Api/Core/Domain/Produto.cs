using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepublicManager.Api.Core.Domain
{
    public class Produto : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int CarrinhoDeCompraId { get; set; }
        public virtual CarrinhoDeCompra CarrinhoDeCompra { get; set; }
        public int UsuarioId { get; set; }
    }
}
