using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Repositories
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        void Remove(int id);
        void Update(TEntity item);
        void Add(TEntity item);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void SetModifiedState(TEntity entity);
    }
}
