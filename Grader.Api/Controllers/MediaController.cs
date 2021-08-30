using Grader.Api.Business.Queries.MediaGet;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Grader.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        public MediaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        /// <summary>
        /// Get a category
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(FileContentResult))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("{key}")]
        public async Task<IActionResult> GetAsync([FromRoute] string key)
        {
            var request = new MediaGetQuery { Key = key};
            var result = await _mediator.Send(request);
            if (result == null) return NotFound();
            return result.Adapt<FileContentResult>();
        }
    }
}
