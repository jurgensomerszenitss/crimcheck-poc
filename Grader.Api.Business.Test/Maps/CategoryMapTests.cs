using Grader.Api.Business.Queries.CategorySearch;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;
using AutoFixture;

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
    }
}
