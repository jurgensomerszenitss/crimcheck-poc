using System.Collections.Generic;

namespace Grader.Api.Business.Queries.CourseSearch
{
    public class CourseSearchQueryResult
    {
        public ICollection<CourseSearchQueryResultCourse> Items { get; set; }
        public int TotalCount { get; set; }
        public CourseSearchQuery Request { get; set; }
    }
}
