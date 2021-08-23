using Grader.Api.Business.Enums;
using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands.LessonUpdate
{
    public class LessonUpdateCommandHandler : IRequestHandler<LessonUpdateCommand, LessonUpdateCommandResult>
    {
        public LessonUpdateCommandHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;


        public async Task<LessonUpdateCommandResult> Handle(LessonUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbContext.Lessons.WhereId(request.Id).SingleOrDefault();
            if (entity == null) return new LessonUpdateCommandResult { Result = UpdateCommandResult.NotFound };
            if(entity.CourseId != request.CourseId) return new LessonUpdateCommandResult { Result = UpdateCommandResult.NotFound };

            entity.Topic = request.Topic;
            entity.Description = request.Description;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Adapt<LessonUpdateCommandResult>();
        }
    }
}
