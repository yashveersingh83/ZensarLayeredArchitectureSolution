using System;
using System.Data.Entity.Validation;
using System.Linq;
using Zensar.Core.DAL.Interfaces;
using Zensar.Core.DBEntities;

namespace Zensar.Core.DAL.Implementation
{
    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        private ZensarDbContext _context;

        public EfUnitOfWork()
        {
            _context = new ZensarDbContext();
        }
        public void Dispose()
        {
           
            _context.Dispose();
            
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new EFRepository<TEntity>(_context);
        }

        public void SaveChanges()
        {
            if (!_context.GetValidationErrors().Any())
            {
                _context.SaveChanges();
                // _transaction.AddPocoToEfContext();
            }
            else
            {
                throw new DbEntityValidationException();
            }
        }
        void IDisposable.Dispose()
        {
            _context.Dispose();
            Dispose();

        }
    }
}
