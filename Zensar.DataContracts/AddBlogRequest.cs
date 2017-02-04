using System.ServiceModel;
using Zensar.Core.DBEntities;

namespace Zensar.DataContracts
{
    [MessageContract(IsWrapped = true)]
    public class AddBlogRequest:RequestBase 
    {
        [MessageBodyMember]
        public Blog Blog { get; set; }
    }

    [MessageContract(IsWrapped = true)]
    public class AddBlogResponse : ResponseBase
    {
        
    }
}