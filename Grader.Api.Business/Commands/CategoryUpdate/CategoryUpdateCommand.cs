using MediatR;
using Newtonsoft.Json;

namespace Grader.Api.Business.Commands.CategoryUpdate
{
    public class CategoryUpdateCommand : IRequest<CategoryUpdateCommandResult>
    {
        [JsonIgnore]
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
