using RepublicManager.Api.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicManager.Api.Core.Resources
{
    public class RegraResource
    {
        public int Id { get; set; }
        public int RepublicaId { get; set; }
        public string Descricao { get; set; }

        public RegraResource()
        {
            isAtivo = true;
        }
        public DateTime DataRegistro { get; set; }
        public bool isAtivo { get; set; }
        public int CriadoPor { get; set; }
    }

    public static class RegraMapper
    {
        public static RegraResource ModelToResource(Regra regra)
        {
            var regraResource = new RegraResource()
            {
                Descricao = regra.Descricao,
                RepublicaId = regra.RepublicaId,

                Id = regra.Id,
                isAtivo = regra.isAtivo,
                CriadoPor = regra.CriadoPor,
                DataRegistro = regra.DataRegistro
            };
            return regraResource;
        }
        public static Regra ResourceToModel(RegraResource regraResource, Regra regra)
        {

            regra.Descricao = regraResource.Descricao;
            regra.RepublicaId = regraResource.RepublicaId;

            regra.Id = regraResource.Id;
            regra.isAtivo = regraResource.isAtivo;
            regra.CriadoPor = regraResource.CriadoPor;
            regra.DataRegistro = regraResource.DataRegistro;

            return regra;
        }
    }
}
