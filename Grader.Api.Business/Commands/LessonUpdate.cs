using Grader.Api.Business.Enums;
using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands
{
    public static class LessonUpdate
    {
        // command
        public record Command([property:JsonIgnore] long Id, [property:JsonIgnore] long CourseId, string Topic, string Description) : IRequest<UpdateCommandResult>;
 
        // handler
        public class Handler : IRequestHandler<Command, UpdateCommandResult>
        {
            public Handler(GraderDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            private readonly GraderDbContext _dbContext;


            public async Task<UpdateCommandResult> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = _dbContext.Lessons.WhereId(request.Id).SingleOrDefault();
                if (entity == null) return  UpdateCommandResult.NotFound;
                if (entity.CourseId != request.CourseId) return UpdateCommandResult.NotFound;

                entity.Topic = request.Topic;
                entity.Description = request.Description;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return UpdateCommandResult.Ok;
            }
        }
    }
}
