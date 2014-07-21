using System;
namespace DataAccess
{
    public interface IRepository<TEntity>
     where TEntity : class
    {
        //void Delete(TEntity entityToDelete);
        //REMOVEd for simplicity
        //System.Collections.Generic.IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<System.Linq.IQueryable<TEntity>, System.Linq.IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        void Delete(object id);
        System.Collections.Generic.IList<TEntity> Get();
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}
