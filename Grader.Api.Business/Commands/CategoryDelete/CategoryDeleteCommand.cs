using MediatR;
using Newtonsoft.Json;

namespace Grader.Api.Business.Commands.CategoryDelete
{
    public class CategoryDeleteCommand : IRequest<CategoryDeleteCommandResult>
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}
