using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Queries.CategoryGet
{
    public class CategoryGetQueryHandler : IRequestHandler<CategoryGetQuery, CategoryGetQueryResult>
    {
        public CategoryGetQueryHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<CategoryGetQueryResult> Handle(CategoryGetQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Categories.WhereId(request.Id).SingleOrDefaultAsync(cancellationToken);
            if (entity == null) return null;

            return entity.Adapt<CategoryGetQueryResult>();
        }
    }
}
