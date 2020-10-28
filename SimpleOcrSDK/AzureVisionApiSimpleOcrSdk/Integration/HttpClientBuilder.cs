using System.Net.Http;

namespace AzureVisionApiSimpleOcrSdk.Integration
{
    public interface IHttpClientBuilder
    {
        HttpClient BuildWithSubscriptionKey(string subscriptionKey);
    }

    public class HttpClientBuilder : IHttpClientBuilder
    {
        public HttpClient BuildWithSubscriptionKey(string subscriptionKey)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            return client;
        }
    }
}