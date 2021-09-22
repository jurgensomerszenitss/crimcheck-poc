using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Queries
{
    public static class LessonGet
    {
        // query
        public record Query([property:JsonIgnore] long Id) : IRequest<Response>;

        // response
        public record Response(long Id, string Topic, string Description, long CourseId);

        // handler
        public class Handler : IRequestHandler<Query, Response>
        {
            public Handler(GraderDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            private readonly GraderDbContext _dbContext;

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = await _dbContext.Lessons.WhereId(request.Id).SingleOrDefaultAsync(cancellationToken);
                if (entity == null) return null;

                return entity.Adapt<Response>();
            }
        }
    }
}
