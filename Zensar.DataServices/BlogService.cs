using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Microsoft.Practices.Unity;
using Zensar.Common;
using Zensar.Core.Business.Interface;
using Zensar.Core.DBEntities;
using Zensar.Core.DBEntities.Filters;
using Zensar.DataContracts;

namespace Zensar.DataServices
{
    [ServiceBehavior(Name = "BlogService", Namespace = "http://zensar.com/2012/08/core/BlogService",
        InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BlogService : IBlogService
    {
        public readonly IRequestProcessor  _RequestProcessor;
        public BlogService()
        {
            _RequestProcessor =      UnityContainerManager.Instance.Resolve<IRequestProcessor>();
        }

         //[PrincipalPermission(SecurityAction.Demand, Role = "")]
        public GetBlogsResponse GetBlogs( GetBlogsRequest request)
        {
            var response = new GetBlogsResponse();
            try
            {
                response.Blogs = _RequestProcessor.GetData<Blog>( request.Filters );
                response.IsSuccess = true;
            }
            catch (Exception t)
            {
                response.IsSuccess = false;
                response.Message = t.StackTrace;

            }
            return response;
        }

        public AddBlogResponse AddBlog(AddBlogRequest request)
        {
            var response = new AddBlogResponse();
            try
            {
                _RequestProcessor.AddData<Blog>(request.Blog);
                response.IsSuccess = true;
            }
            catch (Exception t)
            {
                response.IsSuccess = false;
                response.Message = t.StackTrace;

            }
            return response;
        }
    }




}
