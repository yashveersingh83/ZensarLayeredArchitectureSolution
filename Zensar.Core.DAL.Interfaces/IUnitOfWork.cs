using System;

namespace Zensar.Core.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        //IRepository<SirDataActions> DeleteWorkSheetRepository { get; }
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void SaveChanges();

    }
}