using AutoFixture;
using Grader.Api.Business.Commands.LessonCreate;
using Grader.Api.Business.Commands.LessonUpdate;
using Grader.Api.Business.Enums;
using Grader.Api.Business.Queries.LessonGet;
using Grader.Api.Business.Queries.LessonSearch;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;

namespace Grader.Api.Business.Test.Maps
{
    public class LessonMapTests : TestBase
    {
        public LessonMapTests()
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

        [Test]
        public void When_Map_LessonCreateCommand_To_Lesson()
        {
            // assign
            var input = Fixture.Create<LessonCreateCommand>();

            // act
            var actual = input.Adapt<Lesson>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Topic, actual.Topic);
            Assert.AreEqual(input.Description, actual.Description);
            Assert.AreEqual(input.CourseId, actual.CourseId);
        }

        [Test]
        public void When_Map_Lesson_To_LessonCreateCommandResult()
        {
            // assign
            var input = Fixture.Create<Lesson>();

            // act
            var actual = input.Adapt<LessonCreateCommandResult>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Topic, actual.Topic);
            Assert.AreEqual(input.CourseId, actual.CourseId);
        }

        [Test]
        public void When_Map_Lesson_To_LessonUpdateCommandResult()
        {
            // assign
            var input = Fixture.Create<Lesson>();

            // act
            var actual = input.Adapt<LessonUpdateCommandResult>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Topic, actual.Topic);
            Assert.AreEqual(input.CourseId, actual.CourseId);
            Assert.AreEqual(UpdateCommandResult.Ok, actual.Result);
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
