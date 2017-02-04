using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Zensar.Core.DAL.Interfaces;
using Zensar.Core.DBEntities;

namespace Zensar.Core.DAL.Implementation
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private ZensarDbContext _context;
        public EFRepository(ZensarDbContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public bool AddList(System.Collections.Generic.List<T> entity)
        {
            // for Bul Inserts use sql bulk insert Nugetpackge to improve performance
            throw new System.NotImplementedException();
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Remove(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void RemoveAll()
        {
            Object attr = null;
            attr = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
            if (attr != null)
            {
                var tableAttribute = attr as TableAttribute;

                if (tableAttribute != null)
                {
                    var sql = string.Format("TRUNCATE table  {0}.{1}", tableAttribute.Schema, tableAttribute.Name);
                    _context.Database.ExecuteSqlCommand(sql);
                }
            }
            else
            {
                _context.Set<T>().RemoveRange(_context.Set<T>().Select(x => x));
            }
        }


        public void RemoveAll(System.Linq.Expressions.Expression<System.Func<T, bool>> filter)
        {
            _context.Set<T>().RemoveRange(_context.Set<T>().Where(filter));
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<T> GetAll(System.Linq.Expressions.Expression<System.Func<T, bool>> filter = null, string includeOptions = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if ((filter != null))
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeOptions))
            {
                query = includeOptions.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            var result = query.ToList();

            return result;
        }

        public System.Linq.IQueryable<T> Get()
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }
    }
}
