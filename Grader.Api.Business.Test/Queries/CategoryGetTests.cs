using AutoFixture;
using Grader.Api.Business.Queries;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;

namespace Grader.Api.Business.Test.Queries
{
    public class CategoryGetTests : TestBase
    {
        public CategoryGetTests()
        {
            InitMapTest(); 
        }

        [Test]
        public void When_Map_Category_To_Response()
        {
            // assign
            var input = Fixture.Create<Category>();

            // act
            var actual = input.Adapt<CategoryGet.Response>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Name, actual.Name);
        }
    }
}
