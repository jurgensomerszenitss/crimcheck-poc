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
    public class CategorySearchQueryHandler : IRequestHandler<CategorySearchQuery, CategorySearchQueryResult>
    {
        public CategorySearchQueryHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<CategorySearchQueryResult> Handle(CategorySearchQuery request, CancellationToken cancellationToken)
        {
            var items = await GetItemsAsync(request, cancellationToken);
            var count = await GetCountAsync(request, cancellationToken);

            return Map(request, items, count);
        }

        private async Task<IEnumerable<Category>> GetItemsAsync(CategorySearchQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Categories
                    .Include(i => i.Image)
                    .WhereSearchText(request.SearchText)
                    .Page(request.Page, request.PageSize)
                    .ToListAsync(cancellationToken);
        }

        private async Task<int> GetCountAsync(CategorySearchQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Categories
                .WhereSearchText(request.SearchText)
                .CountAsync(cancellationToken);
        }

        private static CategorySearchQueryResult Map(CategorySearchQuery request, IEnumerable<Category> items, int count)
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
