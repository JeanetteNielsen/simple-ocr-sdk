using AzureVisionApiSimpleOcrSdk.Integration;
using FluentAssertions;
using NUnit.Framework;

namespace AzureVisionApiSimpleOcrSdkTest.Integration
{
    [TestFixture]
    public class HttpClientBuilderTest
    {
        private HttpClientBuilder _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new HttpClientBuilder();
        }

        [Test]
        public void GivenSubscriptionKey_WhenCallingBuild_ThenHttpClientIsReturned()
        {
            //Arrange
            var subscriptionKey = "my awesome key";

            //act
            var result = _sut.BuildWithSubscriptionKey(subscriptionKey);

            //Assert
            result.DefaultRequestHeaders.Contains("Ocp-Apim-Subscription-Key").Should().BeTrue();
            result.DefaultRequestHeaders.GetValues("Ocp-Apim-Subscription-Key").Should().Contain(subscriptionKey);
        }
    }
}
