using Grader.Api.Business.Maps;
using Grader.Api.Data.Context;
using Grader.Api.Data.Model;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Queries
{
    public static class LessonSearch
    {
        // query
        public record Query([property:JsonIgnore] long CourseId, string SearchText, int Page = 1, int PageSize = 10) : IRequest<Response>;

        // response
        public record Response(ICollection<ResponseLesson> Items, long TotalCount, Query Request);
        public record ResponseLesson(long Id,string Topic, string Description, long CourseId);


        // handler
        public class LessonSearchQueryHandler : IRequestHandler<Query, Response>
        {
            public LessonSearchQueryHandler(GraderDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            private readonly GraderDbContext _dbContext;

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var items = await GetItemsAsync(request, cancellationToken);
                var count = await GetCountAsync(request, cancellationToken);

                return Map(request, items, count);
            }

            private async Task<IEnumerable<Lesson>> GetItemsAsync(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Lessons
                     .WhereSearchText(request.SearchText)
                     .WhereCourseId(request.CourseId)
                     .Page(request.Page, request.PageSize)
                     .ToListAsync(cancellationToken);
            }

            private async Task<int> GetCountAsync(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Lessons
                     .WhereSearchText(request.SearchText)
                     .WhereCourseId(request.CourseId)
                    .CountAsync(cancellationToken);
            }

            private static Response Map(Query request, IEnumerable<Lesson> items, int count)
            {
                return new Response
                (
                    items.Select(x => x.Adapt<ResponseLesson>()).ToList(),
                    count,
                    request
                );
            }
        }
    }
}
