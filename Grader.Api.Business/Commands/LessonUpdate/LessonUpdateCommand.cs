using MediatR;
using Newtonsoft.Json;
using System;

namespace Grader.Api.Business.Commands.LessonUpdate
{
    public class LessonUpdateCommand : IRequest<LessonUpdateCommandResult>
    {
        [JsonIgnore]
        public long Id { get; set; }

        [JsonIgnore]
        public long CourseId{ get; set; }

        public string Topic { get; set; }
        public string Description { get; set; } 
    }
}
