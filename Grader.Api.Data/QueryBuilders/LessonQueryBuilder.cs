using Grader.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Grader.Api.Data.QueryBuilders
{
    public static class LessonQueryBuilder
    {
        public static IQueryable<Lesson> WhereSearchText(this IQueryable<Lesson> query, string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return query;
            }

            var searchParts = searchText.Split(",").Where(x => x.Length >= 3);
            var searchExpression = string.Join(" & ", searchParts.Select(x => $"{x}:*"));
            return query.Where(q => q.SearchText.Matches(EF.Functions.ToTsQuery(searchExpression)));
        }

        public static IQueryable<Lesson> WhereId(this IQueryable<Lesson> query, long? id)
        {
            if (!id.HasValue) return query;

            return query.Where(x => x.Id == id);
        }

        public static IQueryable<Lesson> WhereCourseId(this IQueryable<Lesson> query, long? courseId)
        {
            if (!courseId.HasValue) return query;

            return query.Where(x => x.CourseId == courseId);
        }
    }
}
