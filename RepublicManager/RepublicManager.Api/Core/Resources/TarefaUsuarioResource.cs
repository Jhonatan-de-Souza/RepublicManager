using System;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class TarefaUsuarioResource : Base
    {

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioResource Usuario { get; set; }
        public int TarefaId { get; set; }
        public TarefaResource Tarefa { get; set; }
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
                Usuario = UsuarioMapper.ModelToResource(tarefaUsuario.Usuario),
                TarefaId = tarefaUsuario.TarefaId,
                Tarefa = TarefaMapper.ModelToResource(tarefaUsuario.Tarefa),

                NotaAvaliacao = tarefaUsuario.NotaAvaliacao,
                ComentarioAvaliacao = tarefaUsuario.ComentarioAvaliacao,
                IsCompleted = tarefaUsuario.IsCompleted,
                DataDaTarefa = tarefaUsuario.DataDaTarefa,
                DataFimDaTarefa = tarefaUsuario.PrevisaoDeConclusao,

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
            tarefaUsuario.TarefaId = tarefaUsuario.TarefaId;

            tarefaUsuario.NotaAvaliacao = tarefaUsuario.NotaAvaliacao;
            tarefaUsuario.ComentarioAvaliacao = tarefaUsuario.ComentarioAvaliacao;
            tarefaUsuario.IsCompleted = tarefaUsuario.IsCompleted;
            tarefaUsuario.DataDaTarefa = tarefaUsuario.DataDaTarefa;
            tarefaUsuario.PrevisaoDeConclusao = tarefaUsuario.PrevisaoDeConclusao;

            tarefaUsuario.Id = tarefaUsuarioResource.Id;
            tarefaUsuario.IsAtivo = tarefaUsuarioResource.IsAtivo;
            tarefaUsuario.CriadoPor = tarefaUsuarioResource.CriadoPor;
            tarefaUsuario.DataRegistro = (tarefaUsuarioResource.Id > 0) ? tarefaUsuario.DataRegistro : DateTime.Now;

            return tarefaUsuario;
        }
    }
}