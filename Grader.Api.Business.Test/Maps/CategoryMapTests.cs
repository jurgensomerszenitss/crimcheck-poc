using Grader.Api.Business.Queries.CategorySearch;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;
using AutoFixture;
using Grader.Api.Business.Commands.CategoryCreate;
using Grader.Api.Business.Commands.CategoryUpdate;
using Grader.Api.Business.Enums;
using Grader.Api.Business.Queries.CategoryGet;

namespace Grader.Api.Business.Test.Maps
{
    public class CategoryMapTests : TestBase
    {
        public CategoryMapTests()
        {
            InitMapTest();
        }

        [Test]
        public void When_Map_Category_To_CategorySearchQueryResultCategory()
        {
            // assign
            var input = Fixture.Create<Category>();

            // act
            var actual = input.Adapt<CategorySearchQueryResultCategory>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Name, actual.Name);
        }

        [Test]
        public void When_Map_CategoryCreateCommand_To_Category()
        {
            // assign
            var input = Fixture.Create<CategoryCreateCommand>();

            // act
            var actual = input.Adapt<Category>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Name, actual.Name);
        }

        [Test]
        public void When_Map_Category_To_CategoryCreateCommandResult()
        {
            // assign
            var input = Fixture.Create<Category>();

            // act
            var actual = input.Adapt<CategoryCreateCommandResult>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Name, actual.Name);
        }

        [Test]
        public void When_Map_Category_To_CategoryUpdateCommandResult()
        {
            // assign
            var input = Fixture.Create<Category>();

            // act
            var actual = input.Adapt<CategoryUpdateCommandResult>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Name, actual.Name);
            Assert.AreEqual(UpdateCommandResult.Ok, actual.Result);
        }

        [Test]
        public void When_Map_Category_To_CategoryGetQueryResult()
        {
            // assign
            var input = Fixture.Create<Category>();

            // act
            var actual = input.Adapt<CategoryGetQueryResult>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Name, actual.Name);
        }
    }
}
