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
        public TEntity GetById(int id)
        {
            using (var context= new TContext())
            {
                var findResult= context.Set<TEntity>().Find(id);
                return findResult;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var context = new TContext())
            {
                var getAllResult = context.Set<TEntity>().ToList();
                return getAllResult;
            }
        }
        public int GetCount()
        {
            using (var context = new TContext())
            {
                var getCountResult = context.Set<TEntity>().Count();
                return getCountResult;
            }
        }
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void AddRange(IEnumerable<TEntity> entitys)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().AddRange(entitys);
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                entity.UpdateDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void Remove(TEntity entity)
        {
            using (var context = new TContext())
            {
                entity.DidDelete = true;
                entity.UpdateDate = DateTime.Now;
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public void SetActive(TEntity entity,bool IsActive)
        {
            using (var context = new TContext())
            {
                entity.IsActive = IsActive;
                entity.UpdateDate = DateTime.Now;
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();
            }
        }
    }
}
