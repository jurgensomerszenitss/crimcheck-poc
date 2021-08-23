using MediatR;
using Newtonsoft.Json;
using System;

namespace Grader.Api.Business.Commands.LessonCreate
{
    public class LessonCreateCommand : IRequest<LessonCreateCommandResult>
    {
        public string Topic { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public long CourseId { get; set; }
    }
}
