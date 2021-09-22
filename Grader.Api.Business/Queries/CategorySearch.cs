using Grader.Api.Business.Maps;
using Grader.Api.Data.Context;
using Grader.Api.Data.Model;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Queries
{
    public static class CategorySearch
    {
        // query
        public record Query(string SearchText, int Page = 1, int PageSize = 10) : IRequest<Response>;

        // response
        public record Response(ICollection<ResponseCategory> Items, long TotalCount, Query Request);
        public record ResponseCategory(long Id, string Name, [property: JsonConverter(typeof(JsonMediaUrlConverter))] string ImageUrl);


        // handler
        public class CategorySearchQueryHandler : IRequestHandler<Query, Response>
        {
            public CategorySearchQueryHandler(GraderDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            private readonly GraderDbContext _dbContext;

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var items = await GetItemsAsync(request, cancellationToken);
                var count = await GetCountAsync(request, cancellationToken);

                return Map(request, items, count);
            }

            private async Task<IEnumerable<Category>> GetItemsAsync(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Categories
                        .Include(i => i.Image)
                        .WhereSearchText(request.SearchText)
                        .Page(request.Page, request.PageSize)
                        .ToListAsync(cancellationToken);
            }

            private async Task<int> GetCountAsync(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Categories
                    .WhereSearchText(request.SearchText)
                    .CountAsync(cancellationToken);
            }

            private static Response Map(Query request, IEnumerable<Category> items, int count)
            {
                return new Response
                (
                    items.Select(x => x.Adapt<ResponseCategory>()).ToList(),
                    count,
                    request
                );
            }
        }

        public class Map : IRegister
        {
            public void Register(TypeAdapterConfig config)
            {
                config.NewConfig<Category, ResponseCategory>()
                    .Map(dest => dest.ImageUrl, src => src.Image != null ? $"{src.Image.Key}" : string.Empty);
            }
        }
    }
}
