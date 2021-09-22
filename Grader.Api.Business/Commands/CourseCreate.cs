using Grader.Api.Data.Context;
using Grader.Api.Data.Model;
using Mapster;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands
{
    public static class CourseCreate
    {
        // command
        public record Command([property:JsonIgnore] long CategoryId,
            string Title, string Description, DateTime ActiveFrom, DateTime ActiveTo, 
            DateTime RegistrationFrom, DateTime RegistrationTo, 
            int MaxParticipants, int MinParticipants) : IRequest<long>;

        // handler
        public class Handler : IRequestHandler<Command, long>
        {
            public Handler(GraderDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            private readonly GraderDbContext _dbContext;

            public async Task<long> Handle(Command request, CancellationToken cancellationToken)
            {

                var entity = request.Adapt<Course>();

                _dbContext.Courses.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return entity.Id;

            }
        }
    }
}
