using Nutritionist.Data.Entities;
using System.Collections.Generic;

namespace Nutritionist.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity: class, IEntity
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        public int GetCount();
        void  Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entitys);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void SetActive(TEntity entity, bool IsActive);

    }
}
