using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DataAccess
{
   public class GenericRepository<TEntity> where TEntity:class
    {
        private DataBase _db;
        private DbSet<TEntity> _dbset;

        public GenericRepository(DataBase db)
        {
            _db = db;
            _dbset = _db.Set<TEntity>();
        }
        //public virtual IEnumerable<TEntity> Get(Exception<Func<TEntity,bool>> where= null)
        //{

        //}

        public virtual void Creat(TEntity entity)
        {
            _dbset.Add(entity);
            _db.SaveChanges();
        }
        public virtual IEnumerable<TEntity> Read(Expression<Func<TEntity,bool>> Where= null) {
            IQueryable<TEntity> query = _dbset;
            if(Where != null)
                {
                    query = query.Where(Where);

                }
            return query.ToList();
        }
        public virtual TEntity Read(object Id)
        {
            return _dbset.Find(Id);
        }
        public virtual void Update(TEntity entity)
        {
            _dbset.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(TEntity entity)
        {
            if(_db.Entry(entity).State == EntityState.Deleted)
            {
                _dbset.Attach(entity);
            }
            _dbset.Remove(entity);
        }
        public virtual void Delete(object Id)
        {
            var entity = Read(Id);
            Delete(entity);
        }
    }
}
