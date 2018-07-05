using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Resources.Mapping
{
    public static class ConvertResourceToModel
    {
        public static List<Aviso> ConvertAvisoToAvisoResource(IEnumerable<AvisoResource> avisoResource)
        {
            List<Aviso> avisos = new List<Aviso>();
            foreach (var item in avisos)
            {
                var aviso = new Aviso
                {
                    Descricao = item.Descricao,
                    DataAviso = item.DataAviso,
                    Id = item.Id,
                    CriadoPor = item.CriadoPor,
                    isAtivo = item.isAtivo
                };
                avisos.Add(aviso);
            }

            return avisos;
        }
    }
}
