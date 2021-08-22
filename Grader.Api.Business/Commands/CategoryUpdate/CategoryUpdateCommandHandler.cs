using Grader.Api.Business.Enums;
using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands.CategoryUpdate
{
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, CategoryUpdateCommandResult>
    {
        public CategoryUpdateCommandHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;


        public async Task<CategoryUpdateCommandResult> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbContext.Categories.WhereId(request.Id).SingleOrDefault();
            if (entity == null) return new CategoryUpdateCommandResult { Result = UpdateCommandResult.NotFound };

            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync();

            return entity.Adapt<CategoryUpdateCommandResult>();
        }
    }
}
