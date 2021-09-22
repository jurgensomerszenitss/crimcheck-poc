using AutoFixture;
using Grader.Api.Business.Queries;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;

namespace Grader.Api.Business.Test.Queries
{
    public class CourseGetTests : TestBase
    {
        public CourseGetTests()
        {
            InitMapTest();
        }

        [Test]
        public void When_Map_Course_To_Response()
        {
            // assign
            var input = Fixture.Create<Course>();

            // act
            var actual = input.Adapt<CourseGet.Response>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Title, actual.Title);
            Assert.AreEqual(input.ActiveFrom, actual.ActiveFrom);
            Assert.AreEqual(input.ActiveTo, actual.ActiveTo);
            Assert.AreEqual(input.Description, actual.Description);
            Assert.AreEqual(input.CategoryId, actual.CategoryId);
        }
    }
}
