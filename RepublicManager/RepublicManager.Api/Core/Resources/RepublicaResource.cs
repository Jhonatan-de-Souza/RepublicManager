using System;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class RepublicaResource
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Vagas { get; set; }

        public RepublicaResource()
        {
            IsAtivo = true;
        }
        public DateTime DataRegistro { get; set; }
        public bool IsAtivo { get; set; }
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
                IsAtivo = republica.IsAtivo,
                CriadoPor = republica.CriadoPor,
                DataRegistro = republica.DataRegistro
            };
            return republicaResource;
        }
        public static Republica ResourceToModel(RepublicaResource republicaResource, Republica republica)
        {

            republica.Nome = republicaResource.Nome;
            republica.Vagas = republicaResource.Vagas;
            republica.Id = republicaResource.Id;
            republica.IsAtivo = republicaResource.IsAtivo;
            republica.CriadoPor = republicaResource.CriadoPor;
            republica.DataRegistro = republicaResource.DataRegistro;
            
            return republica;
        }
    }

}


