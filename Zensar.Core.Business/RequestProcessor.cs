using System;
using System.Collections.Generic;
using Zensar.Core.Business.Interface;
using Zensar.Core.DAL.Interfaces;
using Zensar.Core.DBEntities.Filters;

namespace Zensar.Core.Business
{
    public class RequestProcessor : IRequestProcessor
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private IUnitOfWork _unit;

        public void CreateUnitOfWork()
        {
            _unit = _unitOfWorkFactory.Create();
            
        }
        
        
        public RequestProcessor(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            CreateUnitOfWork();
        }

        public List<T> GetData<T>(List<FilterCriteria> filterList) where T : class
        {
            using (var unit = _unitOfWorkFactory.Create())
            {
                var r = ExpressionHelper<T>.GenerateFilterExpression(filterList);
                var result = unit.Repository<T>().GetAll(r);
                return result;
            }

        }

        public T AddData<T>(T newList) where T : class
        {
            //Business  validation can be workflow or other complex logi per entity type
            //if (!BusinessValidations.ValidationFactory.GetValidator(newList).Validate())
            //{
            //    return null;
            //}
            
            var r =  _unit.Repository<T>().Add(newList);
            _unit.SaveChanges();
            return r;
        }

        public bool Update<T>(T newList) where T : class
        {
            _unit.Repository<T>().Update(newList);
            return true;
        }

        public bool Delete<T>(T newList) where T : class
        {
            _unit.Repository<T>().Remove(newList);
            return true;
        }

        public void SaveChanges()
        {
            _unit.SaveChanges();
        }

        public bool AddList<T>(List<T> entity) where T : class
        {
            return _unit.Repository<T>().AddList(entity);
        }
        
        public bool DeleteAll<T>(List<FilterCriteria> filterList) where T : class
        {
            if (filterList == null)
            {
                _unit.Repository<T>().RemoveAll();
            }
            else
            {
                var r = ExpressionHelper<T>.GenerateFilterExpression(filterList);
                _unit.Repository<T>().RemoveAll(r);
            }

            return true;
        }
    }
}
