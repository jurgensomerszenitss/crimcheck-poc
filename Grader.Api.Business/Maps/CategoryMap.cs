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
        }
    }
}
