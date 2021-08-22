using MediatR;
using Newtonsoft.Json;

namespace Grader.Api.Business.Queries.CourseSearch
{
    public class CourseSearchQuery : IRequest<CourseSearchQueryResult>
    {
        [JsonIgnore]
        public long? CategoryId { get; set; }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string SearchText { get; set; }
    }
}
