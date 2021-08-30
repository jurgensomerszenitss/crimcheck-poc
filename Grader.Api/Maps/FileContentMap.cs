using Grader.Api.Business.Queries.MediaGet;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Grader.Api.Maps
{
    public class FileContentMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<MediaGetQueryResult, FileContentResult>().ConstructUsing((s) => new FileContentResult(s.Content, $"image/{s.Type}") { FileDownloadName = $"{s.Name}.{s.Type}" });
        }
    }
}
