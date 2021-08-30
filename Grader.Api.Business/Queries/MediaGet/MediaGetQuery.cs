using MediatR;
using Newtonsoft.Json;

namespace Grader.Api.Business.Queries.MediaGet
{
    public class MediaGetQuery : IRequest<MediaGetQueryResult>
    {
        [JsonIgnore]
        public string Key { get; set; }
    }
}
