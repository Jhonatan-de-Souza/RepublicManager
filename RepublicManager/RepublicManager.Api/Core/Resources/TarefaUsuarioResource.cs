using System;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class TarefaUsuarioResource : Base
    {

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
        public int NotaAvaliacao { get; set; }
        public string ComentarioAvaliacao { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DataDaTarefa { get; set; }
        public DateTime DataFimDaTarefa { get; set; }
    }

    public static class TarefaUsuarioMapper
    {
        public static TarefaUsuarioResource ModelToResource(TarefaUsuario tarefaUsuario)
        {
            var tarefaUsuarioResource = new TarefaUsuarioResource()
            {
                UsuarioId = tarefaUsuario.UsuarioId,
                Usuario = tarefaUsuario.Usuario,
                TarefaId = tarefaUsuario.TarefaId,
                Tarefa = tarefaUsuario.Tarefa,
                NotaAvaliacao = tarefaUsuario.NotaAvaliacao,
                ComentarioAvaliacao = tarefaUsuario.ComentarioAvaliacao,
                IsCompleted = tarefaUsuario.IsCompleted,
                DataDaTarefa = tarefaUsuario.DataDaTarefa,
                DataFimDaTarefa = tarefaUsuario.DataFimDaTarefa,

                Id = tarefaUsuario.Id,
                IsAtivo = tarefaUsuario.IsAtivo,
                CriadoPor = tarefaUsuario.CriadoPor,
                DataRegistro = tarefaUsuario.DataRegistro
            };
            return tarefaUsuarioResource;
        }

        public static TarefaUsuario ResourceToModel(TarefaUsuarioResource tarefaUsuarioResource,
            TarefaUsuario tarefaUsuario)
        {

            tarefaUsuario.UsuarioId = tarefaUsuario.UsuarioId;
            tarefaUsuario.Usuario = tarefaUsuario.Usuario;
            tarefaUsuario.TarefaId = tarefaUsuario.TarefaId;
            tarefaUsuario.Tarefa = tarefaUsuario.Tarefa;
            tarefaUsuario.NotaAvaliacao = tarefaUsuario.NotaAvaliacao;
            tarefaUsuario.ComentarioAvaliacao = tarefaUsuario.ComentarioAvaliacao;
            tarefaUsuario.IsCompleted = tarefaUsuario.IsCompleted;
            tarefaUsuario.DataDaTarefa = tarefaUsuario.DataDaTarefa;
            tarefaUsuario.DataFimDaTarefa = tarefaUsuario.DataFimDaTarefa;

            tarefaUsuario.Id = tarefaUsuarioResource.Id;
            tarefaUsuario.IsAtivo = tarefaUsuarioResource.IsAtivo;
            tarefaUsuario.CriadoPor = tarefaUsuarioResource.CriadoPor;
            tarefaUsuario.DataRegistro = (tarefaUsuarioResource.Id > 0) ? tarefaUsuario.DataRegistro : DateTime.Now;

            return tarefaUsuario;
        }
    }
}