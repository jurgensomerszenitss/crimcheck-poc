using Grader.Api.Business.Enums;
using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands
{
    public static class CourseUpdate
    {
        // command
        public record Command([property:JsonIgnore] long Id, 
            [property:JsonIgnore] long CategoryId,
            string Title, string Description, DateTime ActiveFrom, DateTime ActiveTo, 
            DateTime RegistrationFrom, DateTime RegistrationTo, 
            int MaxParticipants, int MinParticipants) : IRequest<UpdateCommandResult>;
 
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
                var entity = _dbContext.Courses.WhereId(request.Id).SingleOrDefault();
                if (entity == null) return  UpdateCommandResult.NotFound;
                if (entity.CategoryId != request.CategoryId) return UpdateCommandResult.NotFound;

                request.Adapt(entity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return UpdateCommandResult.Ok;
            }
        }
    }
}
