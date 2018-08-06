using System;

namespace RepublicManager.Api.Core.Domain
{
    public class TarefaUsuario : Base
    {
        //public int Id { get; set; }
        public int UsuarioId { get; set; }
        public  virtual Usuario Usuario { get; set; }
        public int TarefaId { get; set; }
        public virtual Tarefa Tarefa { get; set; }
        public int NotaAvaliacao { get; set; }
        public string ComentarioAvaliacao { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DataDaTarefa { get; set; }
        public DateTime PrevisaoDeConclusao { get; set; }
    }
}
