using System;
using System.ComponentModel.DataAnnotations;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class AvisoResource :Base
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataAviso { get; set; }
        public string Descricao { get; set; }
    }

    public static class AvisoMapper
    {
        public static AvisoResource ModelToResource(Aviso aviso)
        {
            var avisoResource = new AvisoResource()
            {
                Descricao = aviso.Descricao,
                DataAviso = aviso.DataAviso,
                Id = aviso.Id,
                IsAtivo = aviso.IsAtivo,
                CriadoPor = aviso.CriadoPor,
            };
            return avisoResource;
        }
        public static Aviso ResourceToModel(AvisoResource avisoResource,Aviso aviso)
        {
            aviso.Descricao = avisoResource.Descricao;
            aviso.DataAviso = avisoResource.DataAviso;
            aviso.Id = avisoResource.Id;
                aviso.IsAtivo = avisoResource.IsAtivo;
            aviso.CriadoPor = avisoResource.CriadoPor;
            aviso.DataRegistro = (avisoResource.Id >0)? aviso.DataRegistro : DateTime.Now;
        
            return aviso;
        }
    }
}