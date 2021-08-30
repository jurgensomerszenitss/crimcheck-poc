using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Queries.MediaGet
{
    public class MediaGetQueryMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Media, MediaGetQueryResult>();
        }
    }
}
