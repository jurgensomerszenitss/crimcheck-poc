using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Grader.Api.Infrastructure
{

    public class RemoveTagPrefixOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (string.IsNullOrEmpty(operation.OperationId))
            {
                operation.OperationId = ((ControllerActionDescriptor)context.ApiDescription.ActionDescriptor).ActionName;
            }

        }
    }
}