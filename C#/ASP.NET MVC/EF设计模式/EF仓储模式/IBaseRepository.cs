using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Repository.IRepository
{
    public interface IRepository<TEntity>
    {
        List<TEntity> GetAll();

        TEntity GetById(int Id);

        int Add(TEntity entity);

        int Update(TEntity entity);

        int Delete(int Id);

        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

    }
}
