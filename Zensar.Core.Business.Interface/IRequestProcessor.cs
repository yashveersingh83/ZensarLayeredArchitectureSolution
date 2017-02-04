using System.Collections.Generic;
using Zensar.Core.DBEntities.Filters;

namespace Zensar.Core.Business.Interface
{
    public interface IRequestProcessor
    {
        List<T> GetData<T>(List<FilterCriteria> filterList) where T : class;
        T AddData<T>(T newList) where T : class;
        bool Update<T>(T newList) where T : class;
        bool Delete<T>(T newList) where T : class;
        bool DeleteAll<T>(List<FilterCriteria> filterList) where T : class;
        void SaveChanges();
        void CreateUnitOfWork();
        bool AddList<T>(List<T> entity) where T : class;

    }
}
