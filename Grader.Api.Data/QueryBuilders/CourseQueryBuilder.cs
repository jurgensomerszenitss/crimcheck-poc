using Grader.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Grader.Api.Data.QueryBuilders
{
    public static class CourseQueryBuilder
    {
        public static IQueryable<Course> WhereSearchText(this IQueryable<Course> query, string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return query;
            }

            var searchParts = searchText.Split(",").Where(x => x.Length >= 3);
            var searchExpression = string.Join(" & ", searchParts.Select(x => $"{x}:*"));
            return query.Where(q => q.SearchText.Matches(EF.Functions.ToTsQuery(searchExpression)));
        }

        public static IQueryable<Course> WhereId(this IQueryable<Course> query, long? id)
        {
            if (!id.HasValue) return query;

            return query.Where(x => x.Id == id);
        }

        public static IQueryable<Course> WhereCategoryId(this IQueryable<Course> query, long? categoryId)
        {
            if (!categoryId.HasValue) return query;

            return query.Where(x => x.CategoryId == categoryId);
        }
    }
}
