using MediatR;
using Newtonsoft.Json;
using System;

namespace Grader.Api.Business.Commands.CourseCreate
{
    public class CourseCreateCommand : IRequest<CourseCreateCommandResult>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ActiveFrom { get; set; }
        public DateTime? ActiveTo { get; set; }

        [JsonIgnore]
        public long CategoryId { get; set; }
    }
}
