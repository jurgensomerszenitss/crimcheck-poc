using Grader.Api.Business.Commands.LessonCreate;
using Grader.Api.Business.Commands.LessonUpdate;
using Grader.Api.Business.Enums;
using Grader.Api.Business.Queries.LessonGet;
using Grader.Api.Business.Queries.LessonSearch;
using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Maps
{
    public class LessonMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Lesson, LessonSearchQueryResultLesson>();

            config.NewConfig<LessonCreateCommand, Lesson>();
            config.NewConfig<Lesson, LessonCreateCommandResult>();

            config.NewConfig<LessonUpdateCommand, Lesson>().Ignore(m => m.Id);
            config.NewConfig<Lesson, LessonUpdateCommandResult>()
                .Map(dest => dest.Result, src => UpdateCommandResult.Ok);

            config.NewConfig<Lesson, LessonGetQueryResult>();
        }
    }
}
