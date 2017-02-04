using System;
using System.ServiceModel;
using Zensar.ServiceAgents.BlogServiceClient;

namespace Zensar.ServiceAgents
{

    public interface IBlogServiceAgent
    {
        GetBlogsResponse GetBlogs(GetBlogsRequest request);
    }

    public class BlogServiceAgent : IBlogServiceAgent
    {
        public BlogServiceClient.BlogServiceClient _serviceClient;
        private void SetServiceClient()
        {
            _serviceClient = new BlogServiceClient.BlogServiceClient();
        }

        public GetBlogsResponse GetBlogs(GetBlogsRequest request)
        {
            GetBlogsResponse response;

            try
            {
                if (_serviceClient.State != CommunicationState.Opened) SetServiceClient();
                response = _serviceClient.GetBlogs(request);
            }
            catch (Exception ex)
            {
               // new Logger().LogException(ex);
                response = new GetBlogsResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
            finally
            {
                if (_serviceClient.State != CommunicationState.Faulted)
                {
                    _serviceClient.Close();
                }
                else
                {
                    _serviceClient.Abort();
                }
            }

            return response;
        }
    }
}
