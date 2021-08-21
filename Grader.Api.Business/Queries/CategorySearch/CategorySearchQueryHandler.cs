using Grader.Api.Data.Context;
using Grader.Api.Data.Model;
using Grader.Api.Data.QueryBuilders;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Grader.Api.Business;
using System.Linq;
using Mapster;

namespace Grader.Api.Business.Queries.CategorySearch
{
    public class CategorySearchQueryHandler : IRequestHandler<CategorySearchQueryRequest, CategorySearchQueryResult>
    {
        public CategorySearchQueryHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<CategorySearchQueryResult> Handle(CategorySearchQueryRequest request, CancellationToken cancellationToken)
        {
            var items = await GetItemsAsync(request);
            var count = await GetCountAsync(request);

            return Map(request, items, count);
        }

        private async Task<IEnumerable<Category>> GetItemsAsync(CategorySearchQueryRequest request)
        {
            return await _dbContext.Categories
                    .WhereSearchText(request.SearchText)
                    .Page(request.Page, request.PageSize)
                    .ToListAsync();
        }

        private async Task<int> GetCountAsync(CategorySearchQueryRequest request)
        {
            return await _dbContext.Categories.CountAsync();
        }

        private CategorySearchQueryResult Map(CategorySearchQueryRequest request, IEnumerable<Category> items, int count)
        {
            return new CategorySearchQueryResult
            {
                Items = items.Select(x => x.Adapt<CategorySearchQueryResultCategory>()).ToList(),
                TotalCount = count,
                Request = request
            };
        }
    }
}
