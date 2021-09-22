using Grader.Api.Data.Context;
using Grader.Api.Data.Model;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;


namespace Grader.Api.Business.Commands
{
    public static class CategoryImageUpload
    {
        // command
        public record Command([property:JsonIgnore] long CategoryId,string Name, string Key, string Type, byte[] Content) : IRequest;

        // handler 
        public class Handler : IRequestHandler<Command>
        {
            public Handler(GraderDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            private readonly GraderDbContext _dbContext;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                using (var tx = _dbContext.Database.BeginTransaction())
                {
                    var entity = await GetAsync(request.CategoryId);
                    if (entity != null)
                    {
                        if (entity.ImageId.HasValue)
                        {
                            _dbContext.Media.Remove(entity.Image);
                            entity.Image = null;
                        }
                    }

                    entity.Image = request.Adapt<Media>();
                    await _dbContext.SaveChangesAsync();
                    tx.Commit();
                }

                return new Unit();
            }

            private async Task<Category> GetAsync(long categoryId)
            {
                return await _dbContext.Categories
                    .Include(i => i.Image)
                    .WhereId(categoryId)
                    .SingleOrDefaultAsync();
            }

            private void DeleteOldImageAsync(Media media)
            {

            }
        }
    }
}
