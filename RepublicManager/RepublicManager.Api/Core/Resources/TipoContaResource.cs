using System;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class TipoContaResource : Base
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
       
    }



    public static class TipoContaMapper
    {
        public static TipoContaResource ModelToResource(TipoConta tipoConta)
        {
            var tipoContaResource = new TipoContaResource()
            {
                Descricao = tipoConta.Descricao,

                Id = tipoConta.Id,
                IsAtivo = tipoConta.IsAtivo,
                CriadoPor = tipoConta.CriadoPor,
                DataRegistro = tipoConta.DataRegistro
            };
            return tipoContaResource;
        }
        public static TipoConta ResourceToModel(TipoContaResource tipoContaResource, TipoConta tipoConta)
        {

            tipoConta.Descricao = tipoContaResource.Descricao;

            tipoConta.Id = tipoContaResource.Id;
            tipoConta.IsAtivo = tipoContaResource.IsAtivo;
            tipoConta.CriadoPor = tipoContaResource.CriadoPor;
            tipoConta.DataRegistro = tipoContaResource.DataRegistro;

            return tipoConta;
        }
    }
}
