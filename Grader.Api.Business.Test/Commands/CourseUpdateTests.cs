﻿using AutoFixture;
using Grader.Api.Business.Commands.CourseUpdate;
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

    }
}