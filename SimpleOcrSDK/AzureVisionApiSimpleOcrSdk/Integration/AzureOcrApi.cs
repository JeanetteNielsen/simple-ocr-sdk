using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using AzureVisionApiSimpleOcrSdk.Exceptions;
using AzureVisionApiSimpleOcrSdk.Model;
using Newtonsoft.Json;

namespace AzureVisionApiSimpleOcrSdk.Integration
{
    public class AzureOcrApi
    {
        private readonly IAzureVisionConfigurations _config;
        private readonly IStreamToByteContent _streamToByteContent;
        private readonly IHttpClientBuilder _httpClientBuilder;

        public AzureOcrApi(IAzureVisionConfigurations azureVisionConfigurations, IStreamToByteContent streamToByteContent, IHttpClientBuilder httpClientBuilder)
        {
            _streamToByteContent = streamToByteContent;
            _httpClientBuilder = httpClientBuilder;
            _config = azureVisionConfigurations;
        }

        public virtual async Task<RawAzureOcrResult> Execute(Stream imageStream)
        {
            try
            {
                using (var client = _httpClientBuilder.BuildWithSubscriptionKey(_config.SubscriptionKey))
                {
                    HttpResponseMessage response;

                    using (var content = _streamToByteContent.Execute(imageStream))
                    {
                        response = await client.PostAsync(_config.BuildUri().AbsoluteUri, content);
                    }

                    return JsonConvert.DeserializeObject<RawAzureOcrResult>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                throw new AzureOcrException(e);
            }
        }
    }
}