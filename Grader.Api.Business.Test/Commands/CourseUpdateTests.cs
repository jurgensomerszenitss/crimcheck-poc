using AutoFixture;
using Grader.Api.Business.Commands;
using Grader.Api.Business.Enums;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;


namespace Grader.Api.Business.Test.Commands
{
    public class CourseUpdateTests : TestBase
    {
        public CourseUpdateTests()
        {
            InitMapTest();
        }

        [Test]
        public void When_Map_Command_To_Course()
        {
            // assign
            var input = Fixture.Create<CourseUpdate.Command>();

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

    }
}
