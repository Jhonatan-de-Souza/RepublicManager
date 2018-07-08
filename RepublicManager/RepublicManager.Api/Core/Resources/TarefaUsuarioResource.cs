﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class TarefaUsuarioResource
    {
        public TarefaUsuarioResource()
        {
            isAtivo = true;
        }

        public DateTime DataRegistro { get; set; }
        public bool isAtivo { get; set; }
        public int CriadoPor { get; set; }


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
                isCompleted = tarefaUsuario.isCompleted,
                DataDaTarefa = tarefaUsuario.DataDaTarefa,
                DataFimDaTarefa = tarefaUsuario.DataFimDaTarefa,

                Id = tarefaUsuario.Id,
                isAtivo = tarefaUsuario.isAtivo,
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
            tarefaUsuario.isCompleted = tarefaUsuario.isCompleted;
            tarefaUsuario.DataDaTarefa = tarefaUsuario.DataDaTarefa;
            tarefaUsuario.DataFimDaTarefa = tarefaUsuario.DataFimDaTarefa;

            tarefaUsuario.Id = tarefaUsuarioResource.Id;
            tarefaUsuario.isAtivo = tarefaUsuarioResource.isAtivo;
            tarefaUsuario.CriadoPor = tarefaUsuarioResource.CriadoPor;
            tarefaUsuario.DataRegistro = tarefaUsuarioResource.DataRegistro;

            return tarefaUsuario;
        }
    }
}