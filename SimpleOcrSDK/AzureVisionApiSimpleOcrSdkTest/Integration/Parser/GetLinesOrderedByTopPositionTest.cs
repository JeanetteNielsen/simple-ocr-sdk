using System;
using System.Collections.Generic;
using AzureVisionApiSimpleOcrSdk.Integration.Parser;
using AzureVisionApiSimpleOcrSdk.Model;
using FluentAssertions;
using NUnit.Framework;

namespace AzureVisionApiSimpleOcrSdkTest.Integration.Parser
{
    [TestFixture]
    public class GetLinesOrderedByTopPositionTest
    {
        private GetLinesOrderedByTopPosition _target;

        [SetUp]
        public void Setup()
        {
            _target = new GetLinesOrderedByTopPosition();
        }

        [Test]
        public void GivenNoRawResult_WhenInvokingExecute_ThenArgumentNullExceptionIsThrown()
        {
            //Arrange
            Action action = () => _target.Execute(null);

            //Act
            //Assert
            action.Should().Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null.\r\nParameter name: ocrOutput");
        }

        [Test]
        public void GivenRawResult_WhenInvokingExecute_ThenOrderedLinesAreReturned()
        {
            //Arrange
            var topLine1 = new Line {BoundingBox = "0,5,0,0"};
            var topLine2 = new Line {BoundingBox = "0,200,0,0"};
            var topLine3 = new Line {BoundingBox = "0,201,0,0"};

            var ocrResult = new RawAzureOcrResult()
            {
                Regions = new[]
                {
                    new Region {Lines = new List<Line>() {topLine2, topLine3}},
                    new Region {Lines = new List<Line>() {topLine1}}
                }
            };

            //Act
            var orderedLines = _target.Execute(ocrResult);

            //Assert
            orderedLines.Should().NotBeNull();
            orderedLines.Count.Should().Be(3);
            orderedLines[0].Should().Be(topLine1);
            orderedLines[1].Should().Be(topLine2);
            orderedLines[2].Should().Be(topLine3);
        }

        [Test]
        public void GivenEmptyRawResult_WhenInvokingExecute_ThenNullIsReturned()
        {
            //Arrange
            var ocrResult = new RawAzureOcrResult();

            //Act
            var orderedLines = _target.Execute(ocrResult);

            //Assert
            orderedLines.Should().BeNull();
        }
    }
}