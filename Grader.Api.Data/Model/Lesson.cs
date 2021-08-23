using NpgsqlTypes;

namespace Grader.Api.Data.Model
{
    public class Lesson
    {
        public long Id { get; set; }        
        public string Topic { get; set; }
        public string Description { get; set; }
        public NpgsqlTsVector SearchText { get; set; }

        public long CourseId { get; set; }
        public virtual Course Course { get; set; }

        
    }
}
