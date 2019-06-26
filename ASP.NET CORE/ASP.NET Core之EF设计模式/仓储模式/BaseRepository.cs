using LikeLook.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace LikeLook.Repository
{
    public class BaseRepository<TDbContext, TEntity> : IBaseRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        private readonly TDbContext _context;
        private readonly DbSet<TEntity> entities;
        public BaseRepository(TDbContext context)
        {
            _context = context;
            entities = context.Set<TEntity>();
        }        

        public IQueryable<TEntity> All()
        {
            return entities.AsQueryable().AsNoTracking();
        }

        public int Count()
        {
            return entities.AsNoTracking().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> expression)
        {
            return entities.Where(expression).AsNoTracking().Count();
        }

        public int Delete(Expression<Func<TEntity, bool>> expression, bool isCommit = false)
        {
            entities.RemoveRange(entities.Where(expression));
            if (isCommit)
            {
                return _context.SaveChanges();
            }
            return 0;
        }

        public int Insert(Expression<Func<TEntity, bool>> expression, bool isCommit = false)
        {
            entities.AddRange(entities.Where(expression));
            if (isCommit)
            {
                return _context.SaveChanges();
            }
            return 0;
        }

        public int Update(Expression<Func<TEntity, bool>> expression, bool isCommit = false)
        {
            entities.UpdateRange(entities.Where(expression));
            if (isCommit)
            {
                return _context.SaveChanges();
            }
            return 0;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression)
        {
            return entities.Where(expression).AsNoTracking();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression, int pageIndex, int pageSize)
        {
            return entities.Where(expression).AsNoTracking().Skip((pageIndex-1)*pageSize).Take(pageSize);
        }

        public int SaveChanges(TEntity entity)
        {
            return _context.SaveChanges();
        }
    }
}
