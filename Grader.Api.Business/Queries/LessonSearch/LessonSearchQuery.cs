using MediatR;
using Newtonsoft.Json;

namespace Grader.Api.Business.Queries.LessonSearch
{
    public class LessonSearchQuery : IRequest<LessonSearchQueryResult>
    {
        [JsonIgnore]
        public long? CourseId { get; set; }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string SearchText { get; set; }
    }
}
