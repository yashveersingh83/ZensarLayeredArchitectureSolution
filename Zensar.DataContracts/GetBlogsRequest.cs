using System.ServiceModel;

namespace Zensar.DataContracts
{
     [MessageContract(IsWrapped = true)]
    public class GetBlogsRequest:RequestBase
    {

    }
}
