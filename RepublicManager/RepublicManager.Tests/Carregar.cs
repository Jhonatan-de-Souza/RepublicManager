using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicManager.Tests
{
    public static class Carregar
    {
        public static RepublicManagerContext DadosMemoria()
        {
            var options = new DbContextOptionsBuilder<RepublicManagerContext>()
                .UseInMemoryDatabase(Guid
                .NewGuid().ToString()).Options;

            var contexto = new RepublicManagerContext(options);


            contexto.Republica.AddRange(new List<Republica>()
            {              
                new Republica(){Nome = "Recanto dos Dev", Vagas = 3,CriadoPor = 1,IsAtivo = true,DataRegistro = DateTime.Now  }

            });

            contexto.SaveChanges();

            return contexto;



        }
    }
}