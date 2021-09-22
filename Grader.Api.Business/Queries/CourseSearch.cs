using Grader.Api.Business.Maps;
using Grader.Api.Data.Context;
using Grader.Api.Data.Model;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Queries
{
    public static class CourseSearch
    {
        // query
        public record Query([property:JsonIgnore] long CategoryId, string SearchText, int Page = 1, int PageSize = 10) : IRequest<Response>;

        // response
        public record Response(ICollection<ResponseCourse> Items, long TotalCount, Query Request);
        public record ResponseCourse(long Id, string Title, string Description,
            DateTime ActiveFrom, DateTime ActiveTo, DateTime RegistrationFrom, DateTime RegistrationTo,
            int MaxParticipants, int MinParticipants, long CategoryId);


        // handler
        public class CourseSearchQueryHandler : IRequestHandler<Query, Response>
        {
            public CourseSearchQueryHandler(GraderDbContext dbContext)
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

            private async Task<IEnumerable<Course>> GetItemsAsync(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Courses
                     .WhereSearchText(request.SearchText)
                     .WhereCategoryId(request.CategoryId)
                     .Page(request.Page, request.PageSize)
                     .ToListAsync(cancellationToken);
            }

            private async Task<int> GetCountAsync(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Courses
                     .WhereSearchText(request.SearchText)
                     .WhereCategoryId(request.CategoryId)
                    .CountAsync(cancellationToken);
            }

            private static Response Map(Query request, IEnumerable<Course> items, int count)
            {
                return new Response
                (
                    items.Select(x => x.Adapt<ResponseCourse>()).ToList(),
                    count,
                    request
                );
            }
        }
    }
}
