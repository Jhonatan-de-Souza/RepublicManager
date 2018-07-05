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
                AvisoResource avisoResource = new AvisoResource
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    CriadoPor = item.CriadoPor,
                    DataAviso = item.DataAviso,
                    DataRegistro = item.DataRegistro,
                    isAtivo = item.isAtivo
                };

                avisoResourcesList.Add(avisoResource);
            }
        }


        public static void ConvertRepublicaToRepublicaResource(IEnumerable<Republica> republicas)
        {
            List<RepublicaResource> republicaResources = new List<RepublicaResource>();
            foreach (var item in republicas)
            {
                RepublicaResource republicaResource = new RepublicaResource
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    CriadoPor = item.CriadoPor,
                    Vagas = item.Vagas,
                    DataRegistro = item.DataRegistro,
                    isAtivo = item.isAtivo
                };

                republicaResources.Add(republicaResource);
            }
        }

        public static void ConvertRepublicaToRepublicaResource(Republica republica)
        {
            RepublicaResource republicaResource = new RepublicaResource
            {
                Id = republica.Id,
                Nome = republica.Nome,
                CriadoPor = republica.CriadoPor,
                Vagas = republica.Vagas,
                DataRegistro = republica.DataRegistro,
                isAtivo = republica.isAtivo
            };
        }
    }
}
