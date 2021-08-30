using Grader.Api.Data.Context;
using Grader.Api.Data.Model;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands.CategoryImageUpload
{
    public class CategoryImageUploadCommandHandler : IRequestHandler<CategoryImageUploadCommand>
    {
        public CategoryImageUploadCommandHandler(GraderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly GraderDbContext _dbContext;

        public async Task<Unit> Handle(CategoryImageUploadCommand request, CancellationToken cancellationToken)
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
