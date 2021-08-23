using Grader.Api.Data.Context;
using Grader.Api.Data.Model;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands.LessonCreate
{
    public class LessonCreateCommandHandler : IRequestHandler<LessonCreateCommand, LessonCreateCommandResult>
    {
        public LessonCreateCommandHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<LessonCreateCommandResult> Handle(LessonCreateCommand request, CancellationToken cancellationToken)
        {

            var entity = request.Adapt<Lesson>();

            _dbContext.Lessons.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Adapt<LessonCreateCommandResult>();

        }
    }
}
