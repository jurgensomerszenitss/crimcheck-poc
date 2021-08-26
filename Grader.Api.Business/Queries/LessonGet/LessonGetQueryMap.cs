using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Queries.LessonGet
{
    public class LessonGetQueryMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Lesson, LessonGetQueryResult>();
        }
    }
}
