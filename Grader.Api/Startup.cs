using FluentValidation.AspNetCore;
using Grader.Api.Business;
using Grader.Api.Infrastructure;
using Grader.Api.Policies;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;

namespace Grader.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddMvc(options => { options.Filters.Add<LogExceptionFilter>(); });
            services.AddRouting(options => { options.LowercaseUrls = true; options.LowercaseQueryStrings = true;  });
            services.AddControllers().AddNewtonsoftJson(ConfigureNewtonsoft);
            services.AddMediatR(typeof(Startup), typeof(Bootstrapper));
            services.AddSwaggerGen(ConfigureSwagger);
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddBusiness(Configuration);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(ConfigureJwt);
            services.AddAuthorization(options => options.DefinePolicies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Grader.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureNewtonsoft(MvcNewtonsoftJsonOptions options)
        {
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
        }

        private void ConfigureSwagger(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Grader.Api", Version = "v1" });

            options.SchemaFilter<SwaggerExcludeFilter>();            
            options.SchemaFilter<JsonIgnoreBodyOperationFilter>();
            options.OperationFilter<JsonIgnoreQueryOperationFilter>();
            options.OperationFilter<RemoveTagPrefixOperationFilter>();
            options.MapType<FileStreamResult>(() => new OpenApiSchema { Type = "file", });
            
            var xmlPath = Path.Combine(System.AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
            options.IncludeXmlComments(xmlPath);

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT token",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });


            options.CustomSchemaIds(i => i.Name);
        }


        private void ConfigureJwt(JwtBearerOptions options)
        {
            options.Authority = Configuration["Jwt:authority"];

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidIssuer = Configuration["Jwt:issuer"],

                ValidateAudience = false,
                ValidAudience = Configuration["Jwt:audience"],

                ValidateLifetime = false,
                SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                {
                    var jwt = new JwtSecurityToken(token);
                    return jwt;
                },
            }; 
        } 
       
    }
}
