using MediatR;

namespace Grader.Api.Business.Queries.CategorySearch
{
    public class CategorySearchQuery : IRequest<CategorySearchQueryResult>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string SearchText { get; set; }
    }
}
