using AutoFixture;
using Grader.Api.Business.Commands;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;

namespace Grader.Api.Business.Test.Commands
{
    public class CategoryCreateTests : TestBase
    {
        public CategoryCreateTests()
        {
            InitMapTest();
            CreateMockDbContext();
        }

        [Test]
        public void When_Handle()
        {
            //// assign
            //var input = Fixture.Create<CategoryCreateCommand>();
            //var sut = Fixture.Create<CategoryCreateCommandHandler>();

            //// act
            //var actual = sut.Handle(input, CancellationToken.None).GetAwaiter().GetResult();

            //// assert
            //Assert.NotNull(actual);
            //Assert.AreNotEqual(0, actual.Id);
            //Assert.AreEqual(input.Name, actual.Name);
        }

        [Test]
        public void When_Map_Command_To_Category()
        {
            // assign
            var input = Fixture.Create<CategoryCreate.Command>();

            // act
            var actual = input.Adapt<Category>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Name, actual.Name);
        }
 

    }
}
