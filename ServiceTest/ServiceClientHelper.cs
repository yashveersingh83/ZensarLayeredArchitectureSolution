namespace ServiceTest
{
    class ServiceClientHelper
    {

        public static BlogServiceClient.BlogServiceClient CreateDataImportServiceClient(string name)
        {
            var serviceClient = new BlogServiceClient.BlogServiceClient();

            //serviceClient.ClientCredentials.Windows.ClientCredential.Domain = "DEVSGINFO";
            //serviceClient.ClientCredentials.Windows.ClientCredential.UserName = name;
            //serviceClient.ClientCredentials.Windows.ClientCredential.Password = "Pass@word!";

            //serviceClient.ClientCredentials.Windows.AllowedImpersonationLevel =
            //    System.Security.Principal.TokenImpersonationLevel.Delegation;

            return serviceClient;
        }
    }
}
