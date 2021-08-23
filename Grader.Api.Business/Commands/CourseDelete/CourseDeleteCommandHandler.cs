using Grader.Api.Business.Enums;
using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands.CourseDelete
{
    public class CourseDeleteCommandHandler : IRequestHandler<CourseDeleteCommand, CourseDeleteCommandResult>
    {
        public CourseDeleteCommandHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<CourseDeleteCommandResult> Handle(CourseDeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Categories.Include(x => x.Courses).WhereId(request.Id).SingleOrDefaultAsync(cancellationToken);
            if (entity == null) return new CourseDeleteCommandResult { Result = DeleteCommandResult.NotFound };
            if (entity.Courses.Any()) return new CourseDeleteCommandResult { Result = DeleteCommandResult.NotAllowed };

            _dbContext.Categories.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CourseDeleteCommandResult { Result = DeleteCommandResult.Ok };
        }
    }
}
