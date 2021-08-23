using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Grader.Api.Infrastructure
{

    public class JsonIgnoreQueryOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            context.ApiDescription.ParameterDescriptions
                .Where(d => d.Source.Id == "Query")
                .ToList()
                .ForEach(param =>
                {
                    var toRemove = operation.Parameters.SingleOrDefault(p => p.Name == param.Name);
                    operation.Parameters.Remove(toRemove);

                });
        }
    } 
}