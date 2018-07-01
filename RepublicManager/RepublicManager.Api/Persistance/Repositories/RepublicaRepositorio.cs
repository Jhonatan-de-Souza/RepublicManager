using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting.Internal;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class RepublicaRepositorio : IRepublicaRepositorio
    {
        private readonly RepublicManagerContext _republicManagerContext;

        public RepublicaRepositorio(RepublicManagerContext republicManagerContext)
        {
            _republicManagerContext = republicManagerContext;
           // Add(new Republica { Nome = "Item1" });
        }

        public IEnumerable<Republica> GetAll()
        {
            return _republicManagerContext.Republicas.ToList();
        }

        public void Add(Republica item)
        {
            _republicManagerContext.Republicas.Add(item);
            _republicManagerContext.SaveChanges();
        }

        public Republica Find(int id)
        {
            return _republicManagerContext.Republicas.FirstOrDefault(t => t.RepublicaId == id);
        }

        public void Remove(int id)
        {
            var entity = _republicManagerContext.Republicas.First(t => t.RepublicaId == id);
            _republicManagerContext.Republicas.Remove(entity);
            _republicManagerContext.SaveChanges();
        }

        public void Update(Republica item)
        {
            _republicManagerContext.Republicas.Update(item);
            _republicManagerContext.SaveChanges();
        }
    }
}
