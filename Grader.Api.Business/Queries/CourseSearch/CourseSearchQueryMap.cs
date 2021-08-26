using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Queries.CourseSearch
{
    public class CourseSearchQueryMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Course, CourseSearchQueryResultCourse>(); 
        }
    }
}
