using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Grader.Api.Business.Commands;
using Grader.Api.Business.Enums;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;


namespace Grader.Api.Business.Test.Commands
{
    public class LessonUpdateTests : TestBase
    {
        public LessonUpdateTests()
        {
            InitMapTest();
        }

        [Test]
        public void When_Map_Command_To_Lesson()
        {
            // assign
            var input = Fixture.Create<LessonUpdate.Command>();

            // act
            var actual = input.Adapt<Lesson>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Topic, actual.Topic);
            Assert.AreEqual(input.Description, actual.Description);
            Assert.AreEqual(input.CourseId, actual.CourseId);
        }
    }
}
