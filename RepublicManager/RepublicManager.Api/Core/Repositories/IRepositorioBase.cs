using System.Collections.Generic;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Repositories
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
