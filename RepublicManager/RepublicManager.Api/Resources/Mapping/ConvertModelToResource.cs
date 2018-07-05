using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Resources.Mapping
{
    public static class ConvertModelToResource
    {
        public static void ConvertAvisoToAvisoResource(IEnumerable<Aviso> aviso)
        {
            List<AvisoResource> avisoResourcesList = new List<AvisoResource>();
            foreach (var item in aviso)
            {
                AvisoResource avisoResource = new AvisoResource();
                avisoResource.Id = item.Id;
                avisoResource.Descricao = item.Descricao;
                avisoResource.CriadoPor = item.CriadoPor;
                avisoResource.DataAviso = item.DataAviso;
                avisoResource.DataRegistro = item.DataRegistro;
                avisoResource.isAtivo = item.isAtivo;

                avisoResourcesList.Add(avisoResource);
            }
        }
    }
}
