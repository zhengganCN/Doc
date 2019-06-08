using Auth.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Core;

namespace Auth.Repository
{
    //基类，实体类必须继承该类
    //该类实现仓储的公有方法
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AuthDBContext _context;

        public BaseRepository(AuthDBContext DataCotent)
        {
            _context = DataCotent;
        }

        public DbSet<TEntity> Entities
        {
            get { return _context.Set<TEntity>(); }
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int Id)
        {
            return _context.Set<TEntity>().Find(Id);
        }

        public int Add(TEntity entity)
        {
            Entities.Add(entity);
            return _context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public int Delete(int Id)
        {
            var entity = _context.Set<TEntity>().Find(Id);
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();
        }

        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where<TEntity>(predicate).AsQueryable<TEntity>();
        }
    }
}