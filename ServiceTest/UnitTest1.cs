using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceTest.BlogServiceClient;

namespace ServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetBlogs()
        {
            var client = ServiceClientHelper.CreateDataImportServiceClient("singhy");
            var list = client.GetBlogs( new GetBlogsRequest { Filters = new List<FilterCriteria> {  new FilterCriteria {Name = "Name" ,Value = "Yash"} } }  );
        }

        [TestMethod]
        public void AddBlog()
        {
            var client = ServiceClientHelper.CreateDataImportServiceClient("singhy");
            var bp = new Blog {Name = "NewBlog2", ShortName = "NB2", SubTitle = "Test2"  };
            bp.Posts = new List<Post>{ new Post  {BlogId =  bp.ID,Body = "post body" ,Title = "post title" , Timestamp = DateTime.Now} };
            var list = client.AddBlog(new AddBlogRequest { Blog =bp });
                //(new Add { Filters = new List<FilterCriteria> { new FilterCriteria { Name = "Name", Value = "Yash" } } });
        }
    }
}
