using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Interface
{
    public interface IRepositorioBase
    {
        void Add(Republica item);
        IEnumerable<Republica> GetAll();
        Republica Find(int id);
        void Remove(int id);
        void Update(Republica item);
    }
}
