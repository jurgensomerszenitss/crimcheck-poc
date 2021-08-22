using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Queries.CourseGet
{
    public class CourseGetQueryHandler : IRequestHandler<CourseGetQuery, CourseGetQueryResult>
    {
        public CourseGetQueryHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<CourseGetQueryResult> Handle(CourseGetQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Courses.WhereId(request.Id).SingleOrDefaultAsync();
            if (entity == null) return null;

            return entity.Adapt<CourseGetQueryResult>();
        }
    }
}
