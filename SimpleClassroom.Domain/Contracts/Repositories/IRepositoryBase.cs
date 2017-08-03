using System;
using System.Collections.Generic;

namespace SimpleClassroom.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        TEntity Get(string id);
        IEnumerable<TEntity> Get(Func<TEntity, Boolean> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity FirstOrDefault(Func<TEntity, Boolean> predicate);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void Dispose();
    }
}
