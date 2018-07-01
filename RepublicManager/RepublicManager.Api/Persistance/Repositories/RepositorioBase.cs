using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        private readonly RepublicManagerContext _republicManagerContext;

        public RepositorioBase(RepublicManagerContext republicManagerContext)
        {
            _republicManagerContext = republicManagerContext;
        }

        public void Add(TEntity item)
        {
            _republicManagerContext.Set<TEntity>().Add(item);
        }

        public TEntity Find(int id)
        {
            return _republicManagerContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _republicManagerContext.Set<TEntity>().ToList();
        }

        public void Remove(int id)
        {
            var entity = _republicManagerContext.Set<TEntity>().Find(id);
            _republicManagerContext.Set<TEntity>().Remove(entity);
           // _republicManagerContext.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _republicManagerContext.Set<TEntity>().Update(item);
        }
    }
}
