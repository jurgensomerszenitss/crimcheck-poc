using Grader.Api.Business.Enums;
using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Commands.CourseUpdate
{
    public class CourseUpdateCommandMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {  
            config.NewConfig<CourseUpdateCommand, Course>().Ignore(m => m.Id);
            config.NewConfig<Course, CourseUpdateCommandResult>()
                .Map(dest => dest.Result, src => UpdateCommandResult.Ok);
        }
    }
}
