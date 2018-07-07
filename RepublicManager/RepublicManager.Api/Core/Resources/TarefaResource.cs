using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class TarefaResource
    {
        public TarefaResource()
        {
            isAtivo = true;
        }
        public DateTime DataRegistro { get; set; }
        public bool isAtivo { get; set; }
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
                isAtivo = tarefa.isAtivo,
                CriadoPor = tarefa.CriadoPor,
                DataRegistro = tarefa.DataRegistro
            };
            return tarefaResource;
        }
        public static Tarefa ResourceToModel(TarefaResource tarefaResource, Tarefa tarefa)
        {

            tarefa.Descricao = tarefaResource.Descricao;
            
            tarefa.Id = tarefaResource.Id;
            tarefa.isAtivo = tarefaResource.isAtivo;
            tarefa.CriadoPor = tarefaResource.CriadoPor;
            tarefa.DataRegistro = tarefaResource.DataRegistro;

            return tarefa;
        }
    }
}
