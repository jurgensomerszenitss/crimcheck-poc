using Microsoft.AspNetCore.Builder;

namespace Grader.Api.Infrastructure
{
    public static class UseUrlConversionExtension
    {
        public static IApplicationBuilder UseUrlConversion(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                Business.Environment.SetUri($"{context.Request.Scheme}://{context.Request.Host.Value}");
                await next();
            });

            
            return app;
        }
         
         
    }
}
