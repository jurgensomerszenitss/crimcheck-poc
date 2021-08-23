using System.Collections.Generic;

namespace Grader.Api.Business.Queries.LessonSearch
{
    public class LessonSearchQueryResult
    {
        public ICollection<LessonSearchQueryResultLesson> Items { get; set; }
        public int TotalCount { get; set; }
        public LessonSearchQuery Request { get; set; }
    }
}
