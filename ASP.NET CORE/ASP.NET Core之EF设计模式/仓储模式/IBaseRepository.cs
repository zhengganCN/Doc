using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LikeLook.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All();

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize);

        int Count();

        int Count(Expression<Func<TEntity, bool>> expression);

        int Delete(Expression<Func<TEntity, bool>> expression, bool isCommit = false);

        int Insert(Expression<Func<TEntity, bool>> expression, bool isCommit = false);

        int Update(Expression<Func<TEntity, bool>> expression, bool isCommit = false);

        int SaveChanges(TEntity entity);
    }
}
