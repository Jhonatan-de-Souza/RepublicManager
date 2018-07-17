using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepublicManager.Api.Core.Domain
{
    public class TipoConta : Base
    {

        public int Id { get; set; }
        public string Descricao { get; set; }
    }   
}
