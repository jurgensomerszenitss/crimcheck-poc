using Grader.Api.Business.Enums;
using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands
{
    public static class LessonDelete
    {
        // command
        public record Command(long Id) : IRequest<DeleteCommandResult>;

        // handler
        public class Handler : IRequestHandler<Command, DeleteCommandResult>
        {
            public Handler(GraderDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            private readonly GraderDbContext _dbContext;

            public async Task<DeleteCommandResult> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _dbContext.Lessons.WhereId(request.Id).SingleOrDefaultAsync(cancellationToken);
                _dbContext.Lessons.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return DeleteCommandResult.Ok;
            }
        }
    }
}
