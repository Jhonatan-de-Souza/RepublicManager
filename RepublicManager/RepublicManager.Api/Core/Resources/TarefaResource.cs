using System;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class TarefaResource
    {
        public TarefaResource()
        {
            IsAtivo = true;
        }
        public DateTime DataRegistro { get; set; }
        public bool IsAtivo { get; set; }
        public int CriadoPor { get; set; }
        public int Id { get; set; }
        public string Descricao { get; set; }

    }
    public static class TarefaMapper
    {
        public static TarefaResource ModelToResource(Tarefa tarefa)
        {
            var tarefaResource = new TarefaResource()
            {
                Descricao = tarefa.Descricao,
                
                Id = tarefa.Id,
                IsAtivo = tarefa.IsAtivo,
                CriadoPor = tarefa.CriadoPor,
                DataRegistro = tarefa.DataRegistro
            };
            return tarefaResource;
        }
        public static Tarefa ResourceToModel(TarefaResource tarefaResource, Tarefa tarefa)
        {

            tarefa.Descricao = tarefaResource.Descricao;
            
            tarefa.Id = tarefaResource.Id;
            tarefa.IsAtivo = tarefaResource.IsAtivo;
            tarefa.CriadoPor = tarefaResource.CriadoPor;
            tarefa.DataRegistro = tarefaResource.DataRegistro;

            return tarefa;
        }
    }
}
