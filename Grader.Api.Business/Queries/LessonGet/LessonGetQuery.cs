using MediatR;
using Newtonsoft.Json;

namespace Grader.Api.Business.Queries.LessonGet
{
    public class LessonGetQuery : IRequest<LessonGetQueryResult>
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}
