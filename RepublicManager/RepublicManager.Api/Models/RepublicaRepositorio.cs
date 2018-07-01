using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Interface;

namespace WebApi.Models
{
    public class RepublicaRepositorio : IRepublicaRepositorio
    {
        private readonly Context _context;

        public RepublicaRepositorio(Context context)
        {
            _context = context;
           // Add(new Republica { Nome = "Item1" });
        }

        public IEnumerable<Republica> GetAll()
        {
            return _context.Republicas.ToList();
        }

        public void Add(Republica item)
        {
            _context.Republicas.Add(item);
            _context.SaveChanges();
        }

        public Republica Find(int id)
        {
            return _context.Republicas.FirstOrDefault(t => t.RepublicaId == id);
        }

        public void Remove(int id)
        {
            var entity = _context.Republicas.First(t => t.RepublicaId == id);
            _context.Republicas.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Republica item)
        {
            _context.Republicas.Update(item);
            _context.SaveChanges();
        }
    }
}
