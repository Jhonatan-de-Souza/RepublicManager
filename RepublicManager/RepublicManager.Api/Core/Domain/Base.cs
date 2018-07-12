using System;

namespace RepublicManager.Api.Core.Domain
{
    public class Base
    {
        public Base()
        {
            IsAtivo = true;
        }
        public DateTime DataRegistro { get; set; }
        public bool IsAtivo { get; set; }
        public int CriadoPor { get; set; }
    }
}
