using Grader.Api.Data.Context;
using Grader.Api.Data.Model;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands.CategoryCreate
{
    public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, CategoryCreateCommandResult>
    {
        public CategoryCreateCommandHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<CategoryCreateCommandResult> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {

            var entity = request.Adapt<Category>();

            _dbContext.Categories.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Adapt<CategoryCreateCommandResult>();

        }
    }
}
