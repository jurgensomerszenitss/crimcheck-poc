using Grader.Api.Business.Maps;
using Newtonsoft.Json;

namespace Grader.Api.Business.Queries.CategorySearch
{
    public class CategorySearchQueryResultCategory
    {
        public long Id { get; set; }
        public string Name { get; set; } 

        [JsonConverter(typeof(JsonMediaUrlConverter))]
        public string ImageUrl { get; set; }
    }
}
