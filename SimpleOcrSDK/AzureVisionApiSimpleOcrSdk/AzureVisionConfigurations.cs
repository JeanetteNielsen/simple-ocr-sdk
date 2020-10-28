using System;

namespace AzureVisionApiSimpleOcrSdk
{
    public interface IAzureVisionConfigurations
    {
        string SubscriptionKey { get; }
        string Endpoint { get; }

        Uri BuildUri();
    }

    public class AzureVisionConfigurations : IAzureVisionConfigurations
    {
        private const string VISION_URI = "vision/v2.1/ocr?language=unk&detectOrientation=true";

        public string SubscriptionKey { get; }
        public string Endpoint { get; }

        public AzureVisionConfigurations(string azureVisionApiSubscriptionKey, string endpoint)
        {
            SubscriptionKey = azureVisionApiSubscriptionKey;
            Endpoint = endpoint;
        }

        public Uri BuildUri()
        {
            return new Uri(new Uri(Endpoint), VISION_URI);
        }
    }
}