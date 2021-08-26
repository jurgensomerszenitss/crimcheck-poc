using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Queries.LessonSearch
{
    public class LessonSearchQueryMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Lesson, LessonSearchQueryResultLesson>();
        }
    }
}
