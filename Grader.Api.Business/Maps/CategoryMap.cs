using Grader.Api.Business.Commands.CategoryCreate;
using Grader.Api.Business.Commands.CategoryUpdate;
using Grader.Api.Business.Enums;
using Grader.Api.Business.Queries.CategoryGet;
using Grader.Api.Business.Queries.CategorySearch;
using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Maps
{
    public class CategoryMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Category, CategorySearchQueryResultCategory>();

            config.NewConfig<CategoryCreateCommand, Category>();
            config.NewConfig<Category, CategoryCreateCommandResult>();

            config.NewConfig<CategoryUpdateCommand, Category>().Ignore(m => m.Id);
            config.NewConfig<Category, CategoryUpdateCommandResult>()
                .Map(dest => dest.Result, src => UpdateCommandResult.Ok);

            config.NewConfig<Category, CategoryGetQueryResult>();
        }
    }
}
