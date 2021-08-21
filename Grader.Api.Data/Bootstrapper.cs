using Grader.Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Grader.Api.Data
{
    public static class Bootstrapper
    {
        public static void AddData(this IServiceCollection services, IConfiguration configuration)
        { 
            var connection = configuration.GetConnectionString("grader");
            const ServiceLifetime lifetime = ServiceLifetime.Transient;
            services.AddDbContext<GraderDbContext>(o => o.UseNpgsql(connection), lifetime);

            var dbContext = services.BuildServiceProvider().GetService<GraderDbContext>();
            dbContext.Verify();
        }
    }
}
