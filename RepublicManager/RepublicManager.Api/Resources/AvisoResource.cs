using System;
using System.Collections.Generic;
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
    public static Aviso ResourceToModel(AvisoResource avisoResource)
    {
        var aviso = new Aviso()
        {
            Descricao = avisoResource.Descricao,
            DataAviso = avisoResource.DataAviso,
            Id = avisoResource.Id,
            isAtivo = avisoResource.isAtivo,
            CriadoPor = avisoResource.CriadoPor,
            DataRegistro = avisoResource.DataRegistro
        };
        return aviso;
    }
}
