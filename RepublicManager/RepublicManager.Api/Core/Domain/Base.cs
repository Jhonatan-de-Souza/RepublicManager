using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Core.Domain
{
    public class Base
    {
        public Base()
        {
            IsAtivo = true;
        }

        public DateTime DataRegistro { get; set; }
        //public DateTime DataRegistro
        //{
        //    get
        //    {
        //        var currentTime = DateTime.Now;
        //        return currentTime;
        //    }
        //}

        public bool IsAtivo { get; set; }
        public int CriadoPor { get; set; }
    }
}
