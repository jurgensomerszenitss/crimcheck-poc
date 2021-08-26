using AutoFixture;
using Grader.Api.Business.Queries.LessonSearch;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;

namespace Grader.Api.Business.Test.Queries
{
    public class LessonSearchTests : TestBase
    {
        public LessonSearchTests()
        {
            InitMapTest();
        }

        [Test]
        public void When_Map_Lesson_To_LessonSearchQueryResultLesson()
        {
            // assign
            var input = Fixture.Create<Lesson>();

            // act
            var actual = input.Adapt<LessonSearchQueryResultLesson>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Topic, actual.Topic);
            Assert.AreEqual(input.CourseId, actual.CourseId);
        }
    }
}
