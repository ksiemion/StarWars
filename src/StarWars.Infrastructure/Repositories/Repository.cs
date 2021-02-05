using Microsoft.EntityFrameworkCore;
using StarWars.Core.Domain;
using StarWars.Core.Repositories;
using StarWars.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StarWars.Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDBContext _dbContext;

        public Repository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(int id, params Expression<Func<T, object>>[] includes) where T : BaseEntity
        {
            return ApplyIncludes(includes).SingleOrDefault(x => x.ID == id);
        }

        public ICollection<T> GetAll<T>(params Expression<Func<T, object>>[] includes) where T : BaseEntity
        {
            return ApplyIncludes(includes).ToList();
        }

        public ICollection<T> GetByPage<T>(int pageNumber, int pageSize, params Expression<Func<T, object>>[] includes) where T : BaseEntity
        {
            return ApplyIncludes(includes).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public T GetBy<T>(Expression<Func<T, bool>> expr, params Expression<Func<T, object>>[] includes) where T : BaseEntity
        {
            return ApplyIncludes(includes).FirstOrDefault(expr);
        }

        public ICollection<T> GetAllBy<T>(Expression<Func<T, bool>> expr, params Expression<Func<T, object>>[] includes) where T : BaseEntity
        {
            return ApplyIncludes(includes).Where(expr).ToList();
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }
        public void Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete<T>(int id) where T : BaseEntity
        {
            T entity = _dbContext.Set<T>().SingleOrDefault(x => x.ID == id);
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        private IQueryable<T> ApplyIncludes<T>(params Expression<Func<T, object>>[] includes) where T : BaseEntity
        {
            IQueryable<T> query = null;
            var dbSet = _dbContext.Set<T>();
            if (includes == null)
                return dbSet;

            if (includes.Length > 0)
                query = dbSet.Include(includes[0]);

            for (int i = 1; i < includes.Length; ++i)
            {
                query = query.Include(includes[i]);
            }

            return query ?? dbSet;
        }
    }
}
