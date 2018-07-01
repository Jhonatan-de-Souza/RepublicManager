using System.Collections.Generic;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Repositories
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        void Add(TEntity item);
        IEnumerable<TEntity> GetAll();
        TEntity Find(int id);
        void Remove(int id);
        void Update(TEntity item);
    }
}
