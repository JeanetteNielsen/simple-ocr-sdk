using System.Collections.Generic;
using AzureVisionApiSimpleOcrSdk.Model;
using FluentAssertions;
using NUnit.Framework;

namespace AzureVisionApiSimpleOcrSdkTest.Model
{
    [TestFixture]
    public class RawAzureOcrResultTest
    {
        [Test]
        public void GivenRegions_WhenCallingGetAsPlainText_ThenTextOfAllWordsAreReturned()
        {
            //Arrange 
            var regions = new[]
            {
                new Region
                {
                    Lines = new List<Line>()
                    {
                        new Line {Words = new List<Word>() {new Word {Text = "Test A"}, new Word {Text = "Test B"}}},
                        new Line {Words = new List<Word>() {new Word {Text = "Test C"}}}
                    }
                },
                new Region
                {
                    Lines = new List<Line>()
                    {
                        new Line {Words = new List<Word>() {new Word {Text = "Test D"}, new Word {Text = "Test E"}}},
                    }
                }
            };


            var target = new RawAzureOcrResult(){Regions = regions };

            //Act
            var result = target.GetAsPlainText();

            //Assert
            result.Should().Be("Test A Test B Test C Test D Test E");
        }
    }
}
