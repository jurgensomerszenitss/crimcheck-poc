using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Reflection;

namespace Grader.Api.Infrastructure
{
    public class JsonIgnoreBodyOperationFilter : ISchemaFilter
    {

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null || context.Type == null)
                return;

            var excludedProperties = context.Type.GetProperties()
                                         .Where(t =>
                                                t.GetCustomAttribute<JsonIgnoreAttribute>()
                                                != null);

            foreach (var excludedProperty in excludedProperties)
            {
                if (schema.Properties.Keys.Any(x => x.Equals(excludedProperty.Name, System.StringComparison.InvariantCultureIgnoreCase)))
                {
                    var key = schema.Properties.Keys.First(x => x.Equals(excludedProperty.Name, System.StringComparison.InvariantCultureIgnoreCase));
                    schema.Properties.Remove(key);
                }
            }
        }
    }
}