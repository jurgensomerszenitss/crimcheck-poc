using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Queries.CategorySearch
{
    public class CategorySearchQueryMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Category, CategorySearchQueryResultCategory>()                
                .Map(dest => dest.ImageUrl, src => src.Image != null ?  $"/media/{src.Image.Key}" : string.Empty);
        }
    }
}
