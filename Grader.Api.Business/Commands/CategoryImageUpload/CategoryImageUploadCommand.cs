using Grader.Api.Business.Commands.MediaCreate;
using MediatR;

namespace Grader.Api.Business.Commands.CategoryImageUpload
{
    public class CategoryImageUploadCommand : MediaCreateCommand, IRequest
    {
        public long CategoryId { get; set; }
    }
}
