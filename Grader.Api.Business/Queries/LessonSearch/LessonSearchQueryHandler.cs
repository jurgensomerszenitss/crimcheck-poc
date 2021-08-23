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

namespace Grader.Api.Business.Queries.LessonSearch
{
    public class LessonSearchQueryHandler : IRequestHandler<LessonSearchQuery, LessonSearchQueryResult>
    {
        public LessonSearchQueryHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<LessonSearchQueryResult> Handle(LessonSearchQuery request, CancellationToken cancellationToken)
        {
            var items = await GetItemsAsync(request, cancellationToken);
            var count = await GetCountAsync(request, cancellationToken);

            return Map(request, items, count);
        }

        private async Task<IEnumerable<Lesson>> GetItemsAsync(LessonSearchQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Lessons
                    .WhereSearchText(request.SearchText)
                    .WhereCourseId(request.CourseId)
                    .Page(request.Page, request.PageSize)
                    .ToListAsync(cancellationToken);
        }

        private async Task<int> GetCountAsync(LessonSearchQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Lessons
                .WhereSearchText(request.SearchText)
                .WhereCourseId(request.CourseId)
                .CountAsync(cancellationToken);
        }

        private static LessonSearchQueryResult Map(LessonSearchQuery request, IEnumerable<Lesson> items, int count)
        {
            return new LessonSearchQueryResult
            {
                Items = items.Select(x => x.Adapt<LessonSearchQueryResultLesson>()).ToList(),
                TotalCount = count,
                Request = request
            };
        }
    }
}
