using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Zensar.Core.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        bool AddList(List<T> entity);
        T Update(T entity);
        void Remove(T entity);
        void RemoveAll();
        void RemoveAll(Expression<Func<T, bool>> filter);
        T GetById(int id);
        List<T> GetAll(Expression<Func<T, bool>> filter = null, string includeOptions = null);

        IQueryable<T> Get();
    }
}