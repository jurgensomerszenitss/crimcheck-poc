using Grader.Api.Data.Context;
using Grader.Api.Data.Model;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands.CourseCreate
{
    public class CourseCreateCommandHandler : IRequestHandler<CourseCreateCommand, CourseCreateCommandResult>
    {
        public CourseCreateCommandHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<CourseCreateCommandResult> Handle(CourseCreateCommand request, CancellationToken cancellationToken)
        {

            var entity = request.Adapt<Course>();

            _dbContext.Courses.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Adapt<CourseCreateCommandResult>();

        }
    }
}
