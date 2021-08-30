using Grader.Api.Data;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Grader.Api.Business
{
    public static class Bootstrapper
    {
        public static void AddBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddData(configuration);
        }
    }
}
