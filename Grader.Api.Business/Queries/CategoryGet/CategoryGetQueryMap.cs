using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Queries.CategoryGet
{
    public class CategoryGetQueryMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Category, CategoryGetQueryResult>();
        }
    }
}
