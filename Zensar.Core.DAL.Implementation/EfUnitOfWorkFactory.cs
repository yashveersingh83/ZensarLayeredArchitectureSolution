using Zensar.Core.DAL.Interfaces;

namespace Zensar.Core.DAL.Implementation
{
    public class EfUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string _connectionString;

        public EfUnitOfWorkFactory()
        {

        }

        public EfUnitOfWorkFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IUnitOfWork Create()
        {
            return new EfUnitOfWork();
        }
    }
}
