using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicManager.Api.Core.Domain
{
    public class Aviso : Base
    {
        public int Id { get; set; }
        public DateTime DataAviso { get; set; }
        public string Descricao { get; set; }
    }
}

  
