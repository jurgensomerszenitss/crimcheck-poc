using AutoFixture;
using AutoFixture.AutoMoq;
using Grader.Api.Data.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Grader.Api.Business.Test
{
    public abstract class TestBase
    { 
        public TestBase()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            Fixture = fixture;
        }
        protected IFixture Fixture { get; }

        protected GraderDbContext DbContext { get; private set; }

        protected void InitMapTest()
        {
            TypeAdapterConfig.GlobalSettings.Scan(typeof(Business.Bootstrapper).Assembly);
        }

        protected GraderDbContext CreateMockDbContext()
        {
            var options = new DbContextOptionsBuilder<GraderDbContext>().UseInMemoryDatabase(databaseName: "grader").Options;
            var context = new GraderDbContext(options);

            Fixture.Inject(context);
            DbContext = context;
            return context;
        }
    }
}