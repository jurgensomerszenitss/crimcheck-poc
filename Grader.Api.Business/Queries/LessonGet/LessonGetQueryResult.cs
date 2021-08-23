namespace Grader.Api.Business.Queries.LessonGet
{
    public class LessonGetQueryResult
    {
        public long Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public long CourseId { get; set; }
    }
}
