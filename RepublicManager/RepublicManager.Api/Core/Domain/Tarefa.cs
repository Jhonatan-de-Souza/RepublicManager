using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepublicManager.Api.Core.Domain
{
    public class Tarefa : Base
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual IEnumerable<TarefaUsuario> TarefaUsuarios { get; set; }
    }
}
