using System;

namespace Grader.Api.Business.Commands.LessonCreate
{
    public class LessonCreateCommandResult
    {
        public long Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public long CourseId{ get; set; }
    }
}
