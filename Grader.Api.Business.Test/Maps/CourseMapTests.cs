using AutoFixture;
using Grader.Api.Business.Commands.CourseCreate;
using Grader.Api.Business.Commands.CourseUpdate;
using Grader.Api.Business.Enums;
using Grader.Api.Business.Queries.CourseGet;
using Grader.Api.Business.Queries.CourseSearch;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;

namespace Grader.Api.Business.Test.Maps
{
    public class CourseMapTests : TestBase
    {
        public CourseMapTests()
        {
            InitMapTest();
        }

        [Test]
        public void When_Map_Course_To_CourseSearchQueryResultCourse()
        {
            // assign
            var input = Fixture.Create<Course>();

            // act
            var actual = input.Adapt<CourseSearchQueryResultCourse>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Title, actual.Title);
            Assert.AreEqual(input.ActiveFrom, actual.ActiveFrom);
            Assert.AreEqual(input.ActiveTo, actual.ActiveTo);
            Assert.AreEqual(input.RegistrationFrom, actual.RegistrationFrom);
            Assert.AreEqual(input.RegistrationTo, actual.RegistrationTo);
            Assert.AreEqual(input.Description, actual.Description);
            Assert.AreEqual(input.CategoryId, actual.CategoryId);
        }

        [Test]
        public void When_Map_CourseCreateCommand_To_Course()
        {
            // assign
            var input = Fixture.Create<CourseCreateCommand>();

            // act
            var actual = input.Adapt<Course>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Title, actual.Title);
            Assert.AreEqual(input.ActiveFrom, actual.ActiveFrom);
            Assert.AreEqual(input.ActiveTo, actual.ActiveTo);
            Assert.AreEqual(input.RegistrationFrom, actual.RegistrationFrom);
            Assert.AreEqual(input.RegistrationTo, actual.RegistrationTo);
            Assert.AreEqual(input.Description, actual.Description);
            Assert.AreEqual(input.CategoryId, actual.CategoryId);
        }

        [Test]
        public void When_Map_Course_To_CourseCreateCommandResult()
        {
            // assign
            var input = Fixture.Create<Course>();

            // act
            var actual = input.Adapt<CourseCreateCommandResult>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Title, actual.Title);
            Assert.AreEqual(input.ActiveFrom, actual.ActiveFrom);
            Assert.AreEqual(input.ActiveTo, actual.ActiveTo);
            Assert.AreEqual(input.RegistrationFrom, actual.RegistrationFrom);
            Assert.AreEqual(input.RegistrationTo, actual.RegistrationTo);
            Assert.AreEqual(input.Description, actual.Description);
            Assert.AreEqual(input.CategoryId, actual.CategoryId);
        }

        [Test]
        public void When_Map_Course_To_CourseUpdateCommandResult()
        {
            // assign
            var input = Fixture.Create<Course>();

            // act
            var actual = input.Adapt<CourseUpdateCommandResult>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Title, actual.Title);
            Assert.AreEqual(input.ActiveFrom, actual.ActiveFrom);
            Assert.AreEqual(input.ActiveTo, actual.ActiveTo);
            Assert.AreEqual(input.RegistrationFrom, actual.RegistrationFrom);
            Assert.AreEqual(input.RegistrationTo, actual.RegistrationTo);
            Assert.AreEqual(input.Description, actual.Description);
            Assert.AreEqual(input.CategoryId, actual.CategoryId);
            Assert.AreEqual(UpdateCommandResult.Ok, actual.Result);
        }

        [Test]
        public void When_Map_Course_To_CourseGetQueryResult()
        {
            // assign
            var input = Fixture.Create<Course>();

            // act
            var actual = input.Adapt<CourseGetQueryResult>();

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
