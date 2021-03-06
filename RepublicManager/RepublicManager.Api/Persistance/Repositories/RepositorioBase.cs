﻿using System.Collections.Generic;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _republicManagerContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _republicManagerContext.Set<TEntity>().ToListAsync();
        }

        public void Remove(int id)
        {
            var entity = _republicManagerContext.Set<TEntity>().Find(id);
            _republicManagerContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity item)
        {
            _republicManagerContext.Set<TEntity>().Update(item);
        }
         public void SetModifiedState(TEntity entity)
        {
            //This is the same doing the following ------->  db.Entry(person).State = EntityState.Modified;
            _republicManagerContext.Entry(entity).State = EntityState.Modified;
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            _republicManagerContext.Set<TEntity>().AddRange(entities);
        }
    }
}
