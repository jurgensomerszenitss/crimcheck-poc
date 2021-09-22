using AutoFixture;
using Grader.Api.Business.Commands;
using Grader.Api.Business.Enums;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;
using System.Threading;

namespace Grader.Api.Business.Test.Commands
{
    public class CategoryUpdateTests : TestBase
    {
        public CategoryUpdateTests()
        {
            InitMapTest();
            CreateMockDbContext();
        }

        [Test]
        public void When_Map_Command_To_Category()
        {
            // assign
            var input = Fixture.Create<CategoryUpdate.Command>();

            // act
            var actual = input.Adapt<Category>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Name, actual.Name);
        }



    }
}
