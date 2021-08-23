using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Queries.LessonGet
{
    public class LessonGetQueryHandler : IRequestHandler<LessonGetQuery, LessonGetQueryResult>
    {
        public LessonGetQueryHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<LessonGetQueryResult> Handle(LessonGetQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Lessons.WhereId(request.Id).SingleOrDefaultAsync(cancellationToken);
            if (entity == null) return null;

            return entity.Adapt<LessonGetQueryResult>();
        }
    }
}
