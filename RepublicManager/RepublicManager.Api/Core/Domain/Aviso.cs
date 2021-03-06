﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepublicManager.Api.Core.Domain
{
    public class Aviso : Base
    {
        public int Id { get; set; }
        public DateTime DataAviso { get; set; }
        public string Descricao { get; set; }
        public int RepublicaId { get; set; }
        public virtual Republica Republica { get; set; }
    }
}

  
