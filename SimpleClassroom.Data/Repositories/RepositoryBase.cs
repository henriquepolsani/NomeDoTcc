using SimpleClassroom.Data.Context;
using SimpleClassroom.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SimpleClassroom.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected DefaultContext Db = new DefaultContext();

        public void Add(TEntity entity)
        {
            Db.Set<TEntity>().Add(entity);
            Db.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Db.Set<TEntity>().AddRange(entities);
            Db.SaveChanges();
        }

        public TEntity Get(string id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Get(Func<TEntity, Boolean> predicate)
        {
            return Db.Set<TEntity>().Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity FirstOrDefault(Func<TEntity, Boolean> predicate)
        {
            return Db.Set<TEntity>().FirstOrDefault(predicate);
        }

        public void Delete(TEntity entity)
        {
            Db.Set<TEntity>().Remove(entity);
            Db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
