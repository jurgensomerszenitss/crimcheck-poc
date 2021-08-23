using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace Grader.Api.Data.Context
{

    public class GraderDbContextFactory : IDesignTimeDbContextFactory<GraderDbContext>
    {
        public GraderDbContextFactory()
        {
            ConfigureLogging();
        }

        ~GraderDbContextFactory()
        {
            Log.CloseAndFlush();
        }

        public GraderDbContext CreateDbContext(string[] args)
        {
            Log.Information($"Current directory : {Directory.GetCurrentDirectory()}");            

            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? ""}.json", true)
               .Build();
            var connectionString = configuration.GetConnectionString("grader");
            Log.Information($"Connection string : {connectionString}"); 

            var optionsBuilder = new DbContextOptionsBuilder<GraderDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new GraderDbContext(optionsBuilder.Options);
        }

        private static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .WriteTo.Console()
              .CreateLogger();
        }
    }
}
