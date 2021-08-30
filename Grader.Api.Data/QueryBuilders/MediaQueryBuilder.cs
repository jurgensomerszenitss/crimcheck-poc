using Grader.Api.Data.Model;
using System.Linq;

namespace Grader.Api.Data.QueryBuilders
{
    public static class MediaQueryBuilder
    {
        public static IQueryable<Media> WhereKey(this IQueryable<Media> query, string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return query;

            return query.Where(x => x.Key.ToLower() == key.ToLower());
        }
    }
}
