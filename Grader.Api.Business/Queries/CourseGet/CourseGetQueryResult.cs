using System;

namespace Grader.Api.Business.Queries.CourseGet
{
    public class CourseGetQueryResult
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ActiveFrom { get; set; }
        public DateTime? ActiveTo { get; set; }
        public long CategoryId { get; set; }
    }
}
