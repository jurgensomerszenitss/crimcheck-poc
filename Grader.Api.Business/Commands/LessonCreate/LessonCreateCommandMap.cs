using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Commands.LessonCreate
{
    public class LessonCreateCommandMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LessonCreateCommand, Lesson>();
            config.NewConfig<Lesson, LessonCreateCommandResult>();
        }
    }
}
