using System;
using AzureVisionApiSimpleOcrSdk.Model;
using FluentAssertions;
using NUnit.Framework;

namespace AzureVisionApiSimpleOcrSdkTest.Model
{
    [TestFixture]
    public class RectangleTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("")]
        [TestCase("12,12,12")]
        [TestCase(null)]
        [TestCase("asdasd")]
        public void GivenInvalidBoundingBoxString_WhenCallingFromString_ThenArgumentNullExceptionIsThrown(string boundingBoxString)
        {
            //Arrange
            Action act = () => Rectangle.FromString(boundingBoxString);

            //Act
            //Assert
            act.Should().Throw<Exception>();
        }


        [TestCase("21,22,23,30", 21,22,23,30)]
        [TestCase("22.2,42.6,30,23",22,43,30,23)]
        [TestCase(" 248 , 508 , 247 , 116 ", 248, 508, 247, 116)]
        public void GivenValidBoundingBoxString_WhenCallingFromString_ThenRectangleShouldBeReturned(string boundingBoxString, int left, int top, int width, int height )
        {
            //Arrange
            var result = Rectangle.FromString(boundingBoxString);

            //Act
            //Assert
            result.Left.Should().Be(left);
            result.Top.Should().Be(top);
            result.Width.Should().Be(width);
            result.Height.Should().Be(height);
        }
    }
}