using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicManager.Api.Core.Domain
{
    public class Regra : Base
    {
        public int Id { get; set; }
        public int RepublicaId { get; set; }
        public string Descricao { get; set; }


    }
}
