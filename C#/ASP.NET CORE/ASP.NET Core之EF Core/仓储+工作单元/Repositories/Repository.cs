using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UOW;

namespace Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {   
        private IMongoCollection<TEntity> GetMongoCollection(UnitOfWork uow)
        {
            if (uow==null)
            {
                throw new NullReferenceException();
            }
            return uow.Database.GetCollection<TEntity>(nameof(TEntity));
        }

        public int Delete(TEntity entity)
        {
            var uow = new UnitOfWork();
            var filter = Builders<TEntity>.Filter.Eq("Id", typeof(TEntity).GetProperty("Id").GetValue(entity));
            var result = GetMongoCollection(uow).DeleteOne(filter);
            return (int)result.DeletedCount;
        }

        public int Delete(IList<TEntity> entities)
        {
            var uow = new UnitOfWork();
            var filter = Builders<TEntity>.Filter.Eq("Id", typeof(TEntity).GetProperty("Id").GetValue(entity));
            var result = GetMongoCollection(uow).DeleteMany(filter);
            return (int)result.DeletedCount;
        }

        public Task<int> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(IList<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TEntity Find()
        {
            throw new NotImplementedException();
        }

        public int Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Insert(IList<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(IList<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public int MarkDelete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int MarkDelete(IList<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> MarkDeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> MarkDeleteAsync(IList<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public int UnmarkDelete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int UnmarkDelete(IList<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> UnmarkDeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UnmarkDeleteAsync(IList<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Update(IList<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(IList<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
