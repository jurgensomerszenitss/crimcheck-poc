using System.Collections.Generic;

namespace Grader.Api.Business.Queries.CategorySearch
{
    public class CategorySearchQueryResult
    {
        public ICollection<CategorySearchQueryResultCategory> Items { get; set; }
        public int TotalCount { get; set; }
        public CategorySearchQueryRequest Request{ get; set; }
    }
}
