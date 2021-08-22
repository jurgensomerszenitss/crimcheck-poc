using Grader.Api.Business.Commands.CourseCreate;
using Grader.Api.Business.Commands.CourseUpdate;
using Grader.Api.Business.Enums;
using Grader.Api.Business.Queries.CourseGet;
using Grader.Api.Business.Queries.CourseSearch;
using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Maps
{
    public class CourseMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Course, CourseSearchQueryResultCourse>();

            config.NewConfig<CourseCreateCommand, Course>();
            config.NewConfig<Course, CourseCreateCommandResult>();

            config.NewConfig<CourseUpdateCommand, Course>().Ignore(m => m.Id);
            config.NewConfig<Course, CourseUpdateCommandResult>()
                .Map(dest => dest.Result, src => UpdateCommandResult.Ok);

            config.NewConfig<Course, CourseGetQueryResult>();
        }
    }
}
