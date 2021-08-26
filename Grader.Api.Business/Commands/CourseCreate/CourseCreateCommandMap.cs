using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Commands.CourseCreate
{
    public class CourseCreateCommandMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CourseCreateCommand, Course>();
            config.NewConfig<Course, CourseCreateCommandResult>();
        }
    }
}
