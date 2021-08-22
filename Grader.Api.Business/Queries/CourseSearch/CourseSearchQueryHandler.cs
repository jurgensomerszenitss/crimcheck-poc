using Grader.Api.Data.Context;
using Grader.Api.Data.Model;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Queries.CourseSearch
{
    public class CourseSearchQueryHandler : IRequestHandler<CourseSearchQuery, CourseSearchQueryResult>
    {
        public CourseSearchQueryHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<CourseSearchQueryResult> Handle(CourseSearchQuery request, CancellationToken cancellationToken)
        {
            var items = await GetItemsAsync(request);
            var count = await GetCountAsync(request);

            return Map(request, items, count);
        }

        private async Task<IEnumerable<Course>> GetItemsAsync(CourseSearchQuery request)
        {
            return await _dbContext.Courses
                    .WhereSearchText(request.SearchText)
                    .WhereCategoryId(request.CategoryId)
                    .Page(request.Page, request.PageSize)
                    .ToListAsync();
        }

        private async Task<int> GetCountAsync(CourseSearchQuery request)
        {
            return await _dbContext.Courses
                .WhereSearchText(request.SearchText)
                .WhereCategoryId(request.CategoryId)
                .CountAsync();
        }

        private CourseSearchQueryResult Map(CourseSearchQuery request, IEnumerable<Course> items, int count)
        {
            return new CourseSearchQueryResult
            {
                Items = items.Select(x => x.Adapt<CourseSearchQueryResultCourse>()).ToList(),
                TotalCount = count,
                Request = request
            };
        }
    }
}
