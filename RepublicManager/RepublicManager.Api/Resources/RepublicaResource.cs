using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
}
