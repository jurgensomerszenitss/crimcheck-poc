using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Grader.Api.Data.QueryBuilders
{
    [ExcludeFromCodeCoverage]
    public static class QueryableExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IQueryable<T> Page<T>(this IOrderedQueryable<T> query, int page, int pageSize) where T : class
        {
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IEnumerable<T> Page<T>(this IEnumerable<T> query, int page, int pageSize) where T : class
        {
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
