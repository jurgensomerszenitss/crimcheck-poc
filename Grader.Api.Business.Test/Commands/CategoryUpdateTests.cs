using AutoFixture;
using Grader.Api.Business.Commands.CategoryUpdate;
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
        public void When_Handle()
        {
            //// assign
            //var input = Fixture.Build<CategoryUpdateCommand>().With(p => p.Id, 1).Create();
            //var dbInput = Fixture.Build<Category>().With(p => p.Id, 1).Create();
            //var sut = Fixture.Create<CategoryUpdateCommandHandler>();
            //DbContext.Categories.Add(dbInput);

            //// act
            //var actual = sut.Handle(input, CancellationToken.None).GetAwaiter().GetResult();

            //// assert
            //Assert.NotNull(actual);
            //Assert.AreNotEqual(0, actual.Id);
            //Assert.AreEqual(input.Name, actual.Name);
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

    }
}
