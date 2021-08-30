using Grader.Api.Business.Commands.CategoryImageUpload;
using Mapster;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Grader.Api.Maps
{
    public class FormFileMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<IFormFile, CategoryImageUploadCommand>()
                .Map(dest => dest.Name, src => Path.GetFileNameWithoutExtension(src.FileName).ToLower())
                .Map(dest => dest.Type, src => Path.GetExtension(src.FileName).ToLower().TrimStart('.'))
                .Map(dest => dest.Key, src => Guid.NewGuid())
                .AfterMapping((src, dest) =>
                {
                    var memoryStream = new MemoryStream();
                    src.CopyTo(memoryStream);
                    dest.Content = memoryStream.ToArray();
                });
        }
    }
}
