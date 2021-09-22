using Grader.Api.Business.Commands;
using Grader.Api.Business.Enums;
using Grader.Api.Business.Queries;
using Grader.Api.Policies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Grader.Api.Controllers
{
    [ApiController]
    public class CourseController : ControllerBase
    {
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        /// <summary>
        /// Searches a list of courses for a category
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(CourseSearch.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("category/{categoryId:long}/course")]
        public async Task<IActionResult> SearchByCategoryAsync([FromRoute] long categoryId, [FromQuery] CourseSearch.Query request)
        {
                var result = await _mediator.Send(request with { CategoryId = categoryId });
                return Ok(result);           
        }

        /// <summary>
        /// Searches a list of courses
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(CourseSearch.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("course")]
        public async Task<IActionResult> SearchAsync([FromQuery] CourseSearch.Query request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Get a course
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(CourseGet.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("course/{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var result = await _mediator.Send(new CourseGet.Query(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Create a new course
        /// </summary>
        /// <param name="request"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [Authorize(Policy = PolicyNames.ADMIN)]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost("category/{categoryId:long}/course")]
        public async Task<IActionResult> CreateAsync([FromRoute] long categoryId, [FromBody] CourseCreate.Command request)
        {
            var result = await _mediator.Send(request with { CategoryId = categoryId });
            return Created(new Uri($"/course/{result}", UriKind.Relative), result);
        }

        /// <summary>
        /// Update a course
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoryId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Policy = PolicyNames.ADMIN)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPut("category/{categoryId:long}/course/{id:long}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long categoryId, [FromRoute] long id, [FromBody] CourseUpdate.Command request)
        {
            var result = await _mediator.Send(request with { Id = id, CategoryId = categoryId });
            return Accepted(new Uri($"/course/{id}", UriKind.Relative), result);
        }

        /// <summary>
        /// Delete a course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Policy = PolicyNames.ADMIN)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpDelete("course/{id:long}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            var result = await _mediator.Send(new CourseDelete.Command(id));
            switch (result)
            {
                case DeleteCommandResult.NotAllowed: return Forbid();
                case DeleteCommandResult.NotFound: return NotFound();
            }

            return NoContent();
        }
    }
}
