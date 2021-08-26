using Grader.Api.Business.Enums;
using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Commands.CategoryUpdate
{
    public class CategoryUpdateCommandMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            
            config.NewConfig<CategoryUpdateCommand, Category>().Ignore(m => m.Id);
            config.NewConfig<Category, CategoryUpdateCommandResult>()
                .Map(dest => dest.Result, src => UpdateCommandResult.Ok);

        }
    }
}
