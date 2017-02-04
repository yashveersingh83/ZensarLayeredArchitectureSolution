using System.Collections.Generic;
using System.ServiceModel;
using Zensar.Core.DBEntities.Filters;

namespace Zensar.DataContracts
{
      [MessageContract(IsWrapped = true)]
    public class RequestBase
    {
        public RequestBase()
        {
            Filters  = new List<FilterCriteria>();
        }
       [MessageBodyMember]
        public List<FilterCriteria> Filters { get; set; }
    }
}