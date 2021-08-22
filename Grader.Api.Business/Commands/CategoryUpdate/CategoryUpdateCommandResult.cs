using Grader.Api.Business.Enums;
using Newtonsoft.Json;

namespace Grader.Api.Business.Commands.CategoryUpdate
{
    public class CategoryUpdateCommandResult
    {
        public long Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public UpdateCommandResult Result { get; set; }
    }
}
