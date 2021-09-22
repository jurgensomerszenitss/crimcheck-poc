using AutoFixture;
using Grader.Api.Business.Commands;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;


namespace Grader.Api.Business.Test.Commands
{
    public class LessonCreateTests : TestBase
    {
        public LessonCreateTests()
        {
            InitMapTest();
        }


        [Test]
        public void When_Map_Command_To_Lesson()
        {
            // assign
            var input = Fixture.Create<LessonCreate.Command>();

            // act
            var actual = input.Adapt<Lesson>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Topic, actual.Topic);
            Assert.AreEqual(input.Description, actual.Description);
            Assert.AreEqual(input.CourseId, actual.CourseId);
        } 

    }
}
