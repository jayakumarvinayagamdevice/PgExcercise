using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace PersistenceRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entity);
        void Update(TEntity entityToUpdate);
        void Delete(TEntity entityToDelete);
        void Delete(object id);
        TEntity Get(object id);
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "" );
        IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);
        IEnumerable<TEntity> Get();

    }
}
