using MediatR;
using Newtonsoft.Json;

namespace Grader.Api.Business.Commands.LessonDelete
{
    public class LessonDeleteCommand : IRequest<LessonDeleteCommandResult>
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}
