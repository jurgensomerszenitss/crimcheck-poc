using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Queries.CourseGet
{
    public class CourseGetQueryMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Course, CourseGetQueryResult>();
        }
    }
}
