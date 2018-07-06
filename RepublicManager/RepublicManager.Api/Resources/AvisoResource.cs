using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Resources;

namespace RepublicManager.Api.Resources
{
    public class AvisoResource
    {
        public AvisoResource()
        {
            isAtivo = true;
        }
        public DateTime DataRegistro { get; set; }
        public bool isAtivo { get; set; }
        public int CriadoPor { get; set; }
        [Key]
        public int Id { get; set; }
        public DateTime DataAviso { get; set; }
        public string Descricao { get; set; }
    }

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
            isAtivo = aviso.isAtivo,
            CriadoPor = aviso.CriadoPor,
            DataRegistro = aviso.DataRegistro
        };
        return avisoResource;
    }
    public static Aviso ResourceToModel(AvisoResource avisoResource,Aviso aviso)
    {

        aviso.Descricao = avisoResource.Descricao;
        aviso.DataAviso = avisoResource.DataAviso;
        aviso.Id = avisoResource.Id;
        aviso.isAtivo = avisoResource.isAtivo;
        aviso.CriadoPor = avisoResource.CriadoPor;
        aviso.DataRegistro = avisoResource.DataRegistro;
        
        return aviso;
    }
}
