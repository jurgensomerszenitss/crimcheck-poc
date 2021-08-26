using AutoFixture;
using Grader.Api.Business.Queries.CategoryGet;
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
