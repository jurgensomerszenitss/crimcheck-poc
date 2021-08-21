using Grader.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Grader.Api.Data.QueryBuilders
{
    public static class CategoryQueryBuilder
    {
        public static IQueryable<Category> WhereSearchText(this IQueryable<Category> query, string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return query;
            }

            var searchParts = searchText.Split(",").Where(x => x.Length >= 3);
            var searchExpression = string.Join(" & ", searchParts.Select(x => $"{x}:*"));
            return query.Where(q => q.SearchText.Matches(EF.Functions.ToTsQuery(searchExpression)));
        }
    }
}
