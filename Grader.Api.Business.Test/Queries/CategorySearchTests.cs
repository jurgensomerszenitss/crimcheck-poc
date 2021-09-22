using AutoFixture;
using Grader.Api.Business.Queries;
using Grader.Api.Data.Model;
using Mapster;
using NUnit.Framework;

namespace Grader.Api.Business.Test.Queries
{
    public class CategorySearchTests : TestBase
    {
        public CategorySearchTests()
        {
            InitMapTest();
        }

        [Test]
        public void When_Map_Category_To_ResponseCategory()
        {
            // assign
            var input = Fixture.Create<Category>();

            // act
            var actual = input.Adapt<CategorySearch.ResponseCategory>();

            // assert
            Assert.NotNull(actual);
            Assert.AreEqual(input.Id, actual.Id);
            Assert.AreEqual(input.Name, actual.Name);
            Assert.AreEqual($"{input.Image.Key}", actual.ImageUrl);
        }


    }
}
