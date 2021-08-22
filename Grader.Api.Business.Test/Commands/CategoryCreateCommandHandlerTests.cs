using AutoFixture;
using Grader.Api.Business.Commands.CategoryCreate;
using NUnit.Framework;
using System.Threading;

namespace Grader.Api.Business.Test.Commands
{
    public class CategoryCreateCommandHandlerTests : TestBase
    {
        public CategoryCreateCommandHandlerTests()
        {
            InitMapTest();
            CreateMockDbContext();
        }

        //[Test]
        //public void When_Handle()
        //{
        //    // assign
        //    var input = Fixture.Create<CategoryCreateCommand>();
        //    var sut = Fixture.Create<CategoryCreateCommandHandler>();

        //    // act
        //    var actual = sut.Handle(input, CancellationToken.None).GetAwaiter().GetResult();

        //    // assert
        //    Assert.NotNull(actual);
        //    Assert.AreNotEqual(0, actual.Id);
        //    Assert.AreEqual(input.Name, actual.Name);
        //}
    }
}
