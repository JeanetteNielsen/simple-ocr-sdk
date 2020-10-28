using AzureVisionApiSimpleOcrSdk;
using FluentAssertions;
using NUnit.Framework;

namespace AzureVisionApiSimpleOcrSdkTest
{
    [TestFixture]
    public class AzureVisionConfigurationsTest
    {
        private string _endpoint;
        private string _key;
        private AzureVisionConfigurations _sut;

        [SetUp]
        public void Setup()
        {
            _key = "My awesome key";
            _endpoint = "http://vision.com/something/";
            _sut = new AzureVisionConfigurations(_key, _endpoint);
        }

        [Test]
        public void GivenValidEndpoint_WhenCallingBuildUri_ThenVisionUriIsReturned()
        {
            //Act
            var uri = _sut.BuildUri();

            //Assert
            uri.AbsoluteUri.Should().StartWith(_endpoint);
        }
    }
}
