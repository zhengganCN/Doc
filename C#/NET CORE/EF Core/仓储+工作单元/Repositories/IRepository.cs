using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    interface IRepository<TEntity> where TEntity:class,new()
    {
        public TEntity Find();
        public int Insert(TEntity entity);
        public int Insert(IList<TEntity> entities);
        public Task<int> InsertAsync(TEntity entity);
        public Task<int> InsertAsync(IList<TEntity> entities);
        
        public int Update(TEntity entity);
        public int Update(IList<TEntity> entities);
        public Task<int> UpdateAsync(TEntity entity);
        public Task<int> UpdateAsync(IList<TEntity> entities);
        
        public int Delete(TEntity entity);
        public int Delete(IList<TEntity> entities);
        public Task<int> DeleteAsync(TEntity entity);
        public Task<int> DeleteAsync(IList<TEntity> entities);

        public int MarkDelete(TEntity entity);
        public int MarkDelete(IList<TEntity> entities);
        public Task<int> MarkDeleteAsync(TEntity entity);
        public Task<int> MarkDeleteAsync(IList<TEntity> entities);

        public int UnmarkDelete(TEntity entity);
        public int UnmarkDelete(IList<TEntity> entities);
        public Task<int> UnmarkDeleteAsync(TEntity entity);
        public Task<int> UnmarkDeleteAsync(IList<TEntity> entities);

    }
}
