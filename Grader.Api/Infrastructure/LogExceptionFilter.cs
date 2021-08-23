using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Net;

namespace Grader.Api.Infrastructure
{
    public class LogExceptionFilter : IExceptionFilter
    {
     
        public LogExceptionFilter(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        private readonly IWebHostEnvironment _hostingEnvironment;

        public void OnException(ExceptionContext context)
        {
            Log.Fatal(context.Exception, "An error has occured : {0}", context.Exception.Message);

            var result = new ObjectResult("Something went wrong");
            if (_hostingEnvironment.IsDevelopment())
            {
                result = new ObjectResult(context.Exception);
                
            }
            result.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = result;
        }
    }
}
