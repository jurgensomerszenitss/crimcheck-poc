using MediatR;
using Newtonsoft.Json;

namespace Grader.Api.Business.Queries.CourseGet
{
    public class CourseGetQuery : IRequest<CourseGetQueryResult>
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}
