using MediatR;
using Newtonsoft.Json;

namespace Grader.Api.Business.Commands.CourseDelete
{
    public class CourseDeleteCommand : IRequest<CourseDeleteCommandResult>
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}
