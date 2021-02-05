using StarWars.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace StarWars.Core.Repositories
{
    public interface IRepository
    {
        T GetById<T>(int id, params Expression<Func<T, object>>[] includes) where T : BaseEntity;
        ICollection<T> GetAll<T>(params Expression<Func<T, object>>[] includes) where T : BaseEntity;
        ICollection<T> GetByPage<T>(int pageNumber, int pageSize, params Expression<Func<T, object>>[] includes) where T : BaseEntity;
        T GetBy<T>(Expression<Func<T, bool>> expr, params Expression<Func<T, object>>[] includes) where T : BaseEntity;
        ICollection<T> GetAllBy<T>(Expression<Func<T, bool>> expr, params Expression<Func<T, object>>[] includes) where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(int id) where T : BaseEntity;
    }
}
