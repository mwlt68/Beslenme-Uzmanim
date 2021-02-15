using Nutritionist.Data.Entities;
using System.Collections.Generic;

namespace Nutritionist.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity: class, IEntity
    {
        void  Add(TEntity entity, bool doesSaveChanges = true);
        void AddRange(IEnumerable<TEntity> entitys, bool doesSaveChanges = true);
        void Update(TEntity entity, bool doesSaveChanges = true);
        void Remove(TEntity entity, bool doesSaveChanges = true);
        void SetActive(TEntity entity, bool IsActive, bool doesSaveChanges = true);

    }
}
