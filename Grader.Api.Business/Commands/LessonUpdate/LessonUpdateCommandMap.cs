using Grader.Api.Business.Enums;
using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Commands.LessonUpdate
{
    public class LessonUpdateCommandMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LessonUpdateCommand, Lesson>().Ignore(m => m.Id);
            config.NewConfig<Lesson, LessonUpdateCommandResult>()
                .Map(dest => dest.Result, src => UpdateCommandResult.Ok); 
        }
    }
}
