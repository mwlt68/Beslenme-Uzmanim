using Microsoft.EntityFrameworkCore;
using Nutritionist.Data.Entities;
using Nutritionist.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nutritionist.Data.Repository
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity> 
        where TEntity : class, IEntity
        where TContext : DbContext ,new ()
    {



        public void Add(TEntity entity, bool doesSaveChanges = true)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                if (doesSaveChanges)
                {
                    context.SaveChanges();
                }
            }
        }

        public void AddRange(IEnumerable<TEntity> entitys,bool doesSaveChanges=true)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().AddRange(entitys);
                if (doesSaveChanges)
                {
                    context.SaveChanges();
                }
            }
        }

        public void Update(TEntity entity, bool doesSaveChanges = true)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                entity.UpdateDate = DateTime.Now;
                if (doesSaveChanges)
                {
                    context.SaveChanges();
                }
            }
        }

        public void Remove(TEntity entity, bool doesSaveChanges = true)
        {
            using (var context = new TContext())
            {
                entity.DidDelete = true;
                entity.UpdateDate = DateTime.Now;
                context.Set<TEntity>().Update(entity);
                if (doesSaveChanges)
                {
                    context.SaveChanges();
                }
            }
        }

        public void SetActive(TEntity entity,bool IsActive,bool doesSaveChanges = true)
        {
            using (var context = new TContext())
            {
                entity.IsActive = IsActive;
                entity.UpdateDate = DateTime.Now;
                context.Set<TEntity>().Update(entity);
                if (doesSaveChanges)
                {
                    context.SaveChanges();
                }
            }
        }
    }
}
