using System.Collections.Generic;
using System.ServiceModel;
using Zensar.Core.DBEntities;
using Zensar.DataContracts;

namespace Zensar.DataServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBlogService
    {
        [OperationContract]
        GetBlogsResponse GetBlogs(GetBlogsRequest request);

        [OperationContract]
        AddBlogResponse AddBlog(AddBlogRequest request);
    }
}
