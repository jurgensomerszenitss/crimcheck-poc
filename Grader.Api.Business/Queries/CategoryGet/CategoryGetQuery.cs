using MediatR;
using Newtonsoft.Json;

namespace Grader.Api.Business.Queries.CategoryGet
{
    public class CategoryGetQuery : IRequest<CategoryGetQueryResult>
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}
