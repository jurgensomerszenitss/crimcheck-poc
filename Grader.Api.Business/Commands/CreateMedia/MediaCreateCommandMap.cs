using Grader.Api.Business.Commands.MediaCreate;
using Grader.Api.Data.Model;
using Mapster;

namespace Grader.Api.Business.Commands.CreateMedia
{
    public class MediaCreateCommandMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<MediaCreateCommand, Media>();
        }
    }
}
