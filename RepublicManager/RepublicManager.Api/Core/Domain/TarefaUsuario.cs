﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicManager.Api.Core.Domain
{
    public class TarefaUsuario : Base
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
        public int NotaAvaliacao { get; set; }
        public string ComentarioAvaliacao { get; set; }
        public bool isCompleted { get; set; }
        public DateTime DataDaTarefa { get; set; }
        public DateTime DataFimDaTarefa { get; set; }
    }
}
