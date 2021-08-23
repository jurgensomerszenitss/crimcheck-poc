using Grader.Api.Business.Enums;
using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands.LessonDelete
{
    public class LessonDeleteCommandHandler : IRequestHandler<LessonDeleteCommand, LessonDeleteCommandResult>
    {
        public LessonDeleteCommandHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<LessonDeleteCommandResult> Handle(LessonDeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Lessons.WhereId(request.Id).SingleOrDefaultAsync(cancellationToken);
            if (entity == null) return new LessonDeleteCommandResult { Result = DeleteCommandResult.NotFound };

            _dbContext.Lessons.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new LessonDeleteCommandResult { Result = DeleteCommandResult.Ok };
        }
    }
}
