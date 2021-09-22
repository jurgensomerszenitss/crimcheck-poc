using Grader.Api.Data.Context;
using Grader.Api.Data.Model;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands
{
    public static class CategoryCreate
    {
        // command
        public record Command (string Name) : IRequest<long>;

        // handler
        public class Handler : IRequestHandler<Command,long>
        {
            public Handler(GraderDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            private readonly GraderDbContext _dbContext;

            public async Task<long> Handle(Command request, CancellationToken cancellationToken)
            {

                var entity = request.Adapt<Category>();

                _dbContext.Categories.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return entity.Id;

            } 
        }
    }
}
