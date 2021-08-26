using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Commands.CategoryCreate
{
    public class CategoryCreateCommandMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CategoryCreateCommand, Category>();
            config.NewConfig<Category, CategoryCreateCommandResult>();
        }
    }
}
