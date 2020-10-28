using System.IO;
using AzureVisionApiSimpleOcrSdk.Integration;
using FluentAssertions;
using NUnit.Framework;

namespace AzureVisionApiSimpleOcrSdkTest.Integration
{
    [TestFixture]
    public class StreamToByteContentTest
    {
        private StreamToByteContent _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new StreamToByteContent();
        }

        [Test]
        public void GivenAStream_WhenCallingExecute_ThenAByteContentIsReturnedWithOctetHeader()
        {
            //Arrange
            using (var stream = new MemoryStream())
            {
                //Act
                var content = _sut.Execute(stream);

                //Assert
                content.Headers.ContentType.Should().Be("application/octet-stream");
            }
        }
    }
}