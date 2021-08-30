using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Queries.MediaGet
{
    public class MediaGetQueryHandler : IRequestHandler<MediaGetQuery, MediaGetQueryResult>
    {
        public MediaGetQueryHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<MediaGetQueryResult> Handle(MediaGetQuery request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.Media.WhereKey(request.Key).SingleOrDefaultAsync(cancellationToken);

            if(item !=null)
            {
                return item.Adapt<MediaGetQueryResult>();
            }

            return null;
        }
    }
}
