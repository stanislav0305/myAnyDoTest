using AnyDo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AnyDo.Data.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected AnyDoDbContext dbContext;
        protected readonly DbSet<T> dbset;

        protected BaseRepository(AnyDoDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbset = dbContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbset.Add(entity);

            dbContext.SaveChanges();
        }

        public virtual void AddMany(IList<T> entityList)
        {
            foreach (var entity in entityList)
                dbset.Add(entity);

            if (entityList.Count > 0)
                dbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            dbset.Attach(entity);

            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public virtual void UpdateMany(IList<T> entityList)
        {
            foreach (var entity in entityList)
            {
                dbset.Attach(entity);
                dbContext.Entry(entity).State = EntityState.Modified;
            }

            if (entityList.Count > 0)
                dbContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);

            dbContext.SaveChanges();
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();

            if (objects.Count() > 0)
            {
                foreach (T obj in objects)
                    dbset.Remove(obj);

                dbContext.SaveChanges();
            }
        }

        public virtual void DeleteAll()
        {
            IEnumerable<T> allObjects = dbset.AsEnumerable();

            if (allObjects.Count() > 0)
            {
                foreach (T obj in allObjects)
                    dbset.Remove(obj);

                dbContext.SaveChanges();
            }
        }

        public virtual T GetById(int id)
        {
            return dbset.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbset;
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }

    }

    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddMany(IList<T> entityList);
        void Update(T entity);
        void UpdateMany(IList<T> entityList);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        void DeleteAll();
        T GetById(int Id);
        T Get(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);

    }
}
