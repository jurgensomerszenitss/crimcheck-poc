using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Grader.Api.Business.Commands.CategoryCreate;
using Grader.Api.Business.Commands.LessonCreate;
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

    }
}
