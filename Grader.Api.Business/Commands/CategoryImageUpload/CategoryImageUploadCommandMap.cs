using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Commands.CategoryImageUpload
{
    public class CategoryImageUploadCommandMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CategoryImageUploadCommand, Media>();
        }
    }
}
