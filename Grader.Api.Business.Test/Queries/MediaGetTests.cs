using AutoFixture;
using Grader.Api.Business.Queries.MediaGet;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;

namespace Grader.Api.Business.Test.Queries
{
    public class MediaGetTests : TestBase
    {
        public MediaGetTests()
        {
            InitMapTest();
        }

        [Test]
        public void When_Map_Media_To_MediaGetQueryResult()
        {
            // assign
            var input = Fixture.Create<Media>();

            // act
            var actual = input.Adapt<MediaGetQueryResult>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Name, actual.Name);
            Assert.AreEqual(input.Type, actual.Type);
            Assert.NotNull(actual.Content);
            Assert.AreEqual(input.Content.Length, actual.Content.Length);
        }
    }
}
