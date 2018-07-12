using System;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class TipoContaResource
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public TipoContaResource()
        {
            isAtivo = true;
        }
        public DateTime DataRegistro { get; set; }
        public bool isAtivo { get; set; }
        public int CriadoPor { get; set; }
    }



    public static class TipoContaMapper
    {
        public static TipoContaResource ModelToResource(TipoConta tipoConta)
        {
            var tipoContaResource = new TipoContaResource()
            {
                Descricao = tipoConta.Descricao,

                Id = tipoConta.Id,
                isAtivo = tipoConta.IsAtivo,
                CriadoPor = tipoConta.CriadoPor,
                DataRegistro = tipoConta.DataRegistro
            };
            return tipoContaResource;
        }
        public static TipoConta ResourceToModel(TipoContaResource tipoContaResource, TipoConta tipoConta)
        {

            tipoConta.Descricao = tipoContaResource.Descricao;

            tipoConta.Id = tipoContaResource.Id;
            tipoConta.IsAtivo = tipoContaResource.isAtivo;
            tipoConta.CriadoPor = tipoContaResource.CriadoPor;
            tipoConta.DataRegistro = tipoContaResource.DataRegistro;

            return tipoConta;
        }
    }
}
