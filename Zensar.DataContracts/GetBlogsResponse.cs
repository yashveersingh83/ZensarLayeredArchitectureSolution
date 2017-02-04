using System.Collections.Generic;
using System.ServiceModel;
using Zensar.Core.DBEntities;

namespace Zensar.DataContracts
{
       [MessageContract(IsWrapped = true)]
    public class GetBlogsResponse : ResponseBase
    {
        public GetBlogsResponse()
        {
            Blogs = new List<Blog>();
        }
        public List<Blog> Blogs { get; set; }
    }
}