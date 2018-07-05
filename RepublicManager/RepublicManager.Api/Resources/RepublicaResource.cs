using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Resources
{
    public class RepublicaResource
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Vagas { get; set; }

        public RepublicaResource()
        {
            isAtivo = true;
        }
        public DateTime DataRegistro { get; set; }
        public bool isAtivo { get; set; }
        public int CriadoPor { get; set; }

    }

    public static class RepublicaMapper
    {
        public static RepublicaResource ModelToResource(Republica republica)
        {
            var republicaResource = new RepublicaResource()
            {
                Nome = republica.Nome,
                Vagas = republica.Vagas,
                Id = republica.Id,
                isAtivo = republica.isAtivo,
                CriadoPor = republica.CriadoPor,
                DataRegistro = republica.DataRegistro
            };
            return republicaResource;
        }
        public static Republica ResourceToModel(RepublicaResource republicaResource)
        {
            var republica = new Republica()
            {
                Nome = republicaResource.Nome,
                Vagas = republicaResource.Vagas,
                Id = republicaResource.Id,
                isAtivo = republicaResource.isAtivo,
                CriadoPor = republicaResource.CriadoPor,
                DataRegistro = republicaResource.DataRegistro
            };
            return republica;
        }
    }

}


