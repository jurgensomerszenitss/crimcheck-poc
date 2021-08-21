using Grader.Api.Business.Queries.CategorySearch;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Grader.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        /// <summary>
        /// Searches a list of courses
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(CategorySearchQueryResult), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CategorySearchQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
