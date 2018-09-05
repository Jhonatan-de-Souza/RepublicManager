using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepublicManager.Api.Core.Domain
{
    public class Usuario : Base
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataFinalContrato { get; set; }
        public int? ContaId { get; set; }
        public virtual Conta Conta { get; set; }
        public int? RepublicaId { get; set; }
        public virtual Republica Republica { get; set; }
        public virtual IEnumerable<TarefaUsuario> TarefaUsuarios { get; set; }
    }
}