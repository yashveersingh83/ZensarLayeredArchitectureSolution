using System.ServiceModel;

namespace Zensar.DataContracts
{
      [MessageContract(IsWrapped = true)]
    public class ResponseBase
    {
          [MessageBodyMember]
        public bool IsSuccess { get; set; }
          [MessageBodyMember]
        public string  Message { get; set; }      
    }
}