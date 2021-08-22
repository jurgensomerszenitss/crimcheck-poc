using Grader.Api.Business.Enums;
using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands.CategoryDelete
{
    public class CategoryDeleteCommandHandler : IRequestHandler<CategoryDeleteCommand, CategoryDeleteCommandResult>
    {
        public CategoryDeleteCommandHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<CategoryDeleteCommandResult> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Categories.Include(x => x.Courses).WhereId(request.Id).SingleOrDefaultAsync();
            if (entity == null) return new CategoryDeleteCommandResult { Result = DeleteCommandResult.NotFound };
            if (entity.Courses.Any()) return new CategoryDeleteCommandResult { Result = DeleteCommandResult.NotAllowed };

            _dbContext.Categories.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return new CategoryDeleteCommandResult { Result = DeleteCommandResult.Ok };
        }
    }
}
