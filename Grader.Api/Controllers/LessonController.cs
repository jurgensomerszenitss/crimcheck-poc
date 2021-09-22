
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
    public class LessonController : ControllerBase
    {
        public LessonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        /// <summary>
        /// Searches a list of lesons for a course
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(LessonSearch.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("course/{courseId:long}/Lesson")]
        public async Task<IActionResult> SearchByCourseAsync([FromRoute] long courseId, [FromQuery] LessonSearch.Query request)
        {
                var result = await _mediator.Send(request with { CourseId = courseId });
                return Ok(result);           
        }

        /// <summary>
        /// Searches a list of Lessons
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(LessonSearch.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("Lesson")]
        public async Task<IActionResult> SearchAsync([FromQuery] LessonSearch.Query request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Get a Lesson
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(LessonGet.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("lesson/{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var result = await _mediator.Send(new LessonGet.Query(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Create a new Lesson
        /// </summary>
        /// <param name="request"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [Authorize(Policy = PolicyNames.ADMIN)]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost("course/{courseId:long}/lesson")]
        public async Task<IActionResult> CreateAsync([FromRoute] long courseId, [FromBody] LessonCreate.Command request)
        {
            var result = await _mediator.Send(request with { CourseId = courseId });
            return Created(new Uri($"/lesson/{result}", UriKind.Relative), result);
        }

        /// <summary>
        /// Update a Lesson
        /// </summary>
        /// <param name="id"></param>
        /// <param name="courseId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Policy = PolicyNames.ADMIN)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPut("course/{courseId:long}/lesson/{id:long}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long courseId, [FromRoute] long id, [FromBody] LessonUpdate.Command request)
        {
            var result = await _mediator.Send(request with { Id = id, CourseId = courseId });
            return Accepted(new Uri($"/lesson/{id}", UriKind.Relative), result);
        }

        /// <summary>
        /// Delete a Lesson
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Policy = PolicyNames.ADMIN)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpDelete("lesson/{id:long}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            var result = await _mediator.Send(new LessonDelete.Command(id));
            switch (result)
            {
                case DeleteCommandResult.NotAllowed: return Forbid();
                case DeleteCommandResult.NotFound: return NotFound();
            }

            return NoContent();
        }
    }
}
