using Grader.Api.Business.Enums;
using Newtonsoft.Json;
using System;

namespace Grader.Api.Business.Commands.LessonUpdate
{
    public class LessonUpdateCommandResult
    {
        public long Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; } 
        public long CourseId{ get; set; }

        [JsonIgnore]
        public UpdateCommandResult Result { get; set; }
    }
}
