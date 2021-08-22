using Grader.Api.Business.Enums;
using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands.CourseUpdate
{
    public class CourseUpdateCommandHandler : IRequestHandler<CourseUpdateCommand, CourseUpdateCommandResult>
    {
        public CourseUpdateCommandHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;


        public async Task<CourseUpdateCommandResult> Handle(CourseUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbContext.Courses.WhereId(request.Id).SingleOrDefault();
            if (entity == null) return new CourseUpdateCommandResult { Result = UpdateCommandResult.NotFound };
            if(entity.CategoryId != request.CategoryId) return new CourseUpdateCommandResult { Result = UpdateCommandResult.NotFound };

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.ActiveFrom = request.ActiveFrom;
            entity.ActiveTo = request.ActiveTo;

            await _dbContext.SaveChangesAsync();

            return entity.Adapt<CourseUpdateCommandResult>();
        }
    }
}
