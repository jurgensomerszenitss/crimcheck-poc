using AutoFixture;
using AutoFixture.AutoMoq;
using Mapster;
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

        protected void InitMapTest()
        {
            TypeAdapterConfig.GlobalSettings.Scan(typeof(Business.Bootstrapper).Assembly);
        }
    }
}