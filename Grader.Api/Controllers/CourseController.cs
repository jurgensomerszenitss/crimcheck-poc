using Grader.Api.Business.Commands.CourseCreate;
using Grader.Api.Business.Commands.CourseDelete;
using Grader.Api.Business.Commands.CourseUpdate;
using Grader.Api.Business.Enums;
using Grader.Api.Business.Queries.CourseGet;
using Grader.Api.Business.Queries.CourseSearch;
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
        [ProducesResponseType(typeof(CourseSearchQueryResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("category/{categoryId:long}/course")]
        public async Task<IActionResult> SearchByCategoryAsync([FromRoute] long categoryId, [FromQuery] CourseSearchQuery request)
        {
            request.CategoryId = categoryId;
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Searches a list of courses
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(CourseSearchQueryResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("course")]
        public async Task<IActionResult> SearchAsync([FromQuery] CourseSearchQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Get a course
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(CourseSearchQueryResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("course/{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var request = new CourseGetQuery { Id = id };
            var result = await _mediator.Send(request);
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
        [ProducesResponseType(typeof(CourseCreateCommandResult), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost("category/{categoryId:long}/course")]
        public async Task<IActionResult> CreateAsync([FromRoute] long categoryId, [FromBody] CourseCreateCommand request)
        {
            request.CategoryId = categoryId;
            var result = await _mediator.Send(request);
            return Created(new Uri($"/course/{result.Id}", UriKind.Relative), result);
        }

        /// <summary>
        /// Update a course
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoryId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Policy = PolicyNames.ADMIN)]
        [ProducesResponseType(typeof(CourseUpdateCommandResult), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPut("category/{categoryId:long}/course/{id:long}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long categoryId, [FromRoute] long id, [FromBody] CourseUpdateCommand request)
        {
            request.Id = id;
            request.CategoryId = categoryId;
            var result = await _mediator.Send(request);
            return Accepted(new Uri($"/Course/{result.Id}", UriKind.Relative), result);
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
            var request = new CourseDeleteCommand { Id = id };
            var result = await _mediator.Send(request);
            switch (result.Result)
            {
                case DeleteCommandResult.NotAllowed: return Forbid();
                case DeleteCommandResult.NotFound: return NotFound();
            }

            return NoContent();
        }
    }
}
