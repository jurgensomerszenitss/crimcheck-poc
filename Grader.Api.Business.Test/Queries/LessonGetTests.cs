using AutoFixture;
using Grader.Api.Business.Queries.LessonGet;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;

namespace Grader.Api.Business.Test.Queries
{
    public class LessonGetTests : TestBase
    {
        public LessonGetTests()
        {
            InitMapTest();
        }


        [Test]
        public void When_Map_Lesson_To_LessonGetQueryResult()
        {
            // assign
            var input = Fixture.Create<Lesson>();

            // act
            var actual = input.Adapt<LessonGetQueryResult>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Topic, actual.Topic);
            Assert.AreEqual(input.CourseId, actual.CourseId);
        }
    }
}
