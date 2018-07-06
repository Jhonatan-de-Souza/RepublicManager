using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicManager.Api.Core.Domain
{
    public class Republica : Base
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Vagas { get; set; }
    }
}
